using System.Diagnostics.CodeAnalysis;
using Microsoft.Extensions.DependencyInjection;

namespace h_work.lesson5.example2
{
    /// <summary>
    /// Воркер - это единица работы, который постоянно запрашивает задачи из камунды на обработку.
    /// Обработчик - специализированно помеченный атрибутом класс, для обработки конкретного блока из BPMN схемы.
    /// 
    /// Поскольку камунда 7 работает через лонг поллинг, мы вынуждены делать это именно таким образом.
    /// Все воркеры запускаются при старте приложения.
    /// 
    /// При добавлении нового воркера в своем микросервисе, важно понимать как он работает
    /// - за 1 запрос, можно забрать более чем 1 задачу на обработку.
    /// - во время исполнения, обработчик завершается успехом/ошибкой, сигнализируем об этом камунду, тогда обработка процесса пойдет дальше.
    /// - ресурсы камунды 7 ограничены, и не стоит забывать про факт, что на продакшене поднято 2 пода.
    /// - не нужно создавать много воркеров, 1 воркер может забирать задачи сразу для множества указанных обработчиков.
    /// - если все таки воркер не справляется, можно увеличить таймаут лонг поллинга, и количество забираемых задач - этого будет достаточно.
    /// 
    /// Обязательно в конкретном обработчике смотрите на период время (на сколько выполнение задачи будет заблокировано выполняющим воркером)
    /// Если обработчик не справился с обработкой кода за период блокировки - ТО ОН ВЫЗОВЕТСЯ ЕЩЕ РАЗ !!
    /// поэтому в обработчиках где есть вызовы внешних сервисов, нужно ограничивать таймауты меньшием чем период блокировки
    ///
    /// Собственно поэтому все обработчики должны быть идемпотентными, иначе в процессе может что-то пойти не так.
    
    /// </summary>
    public sealed class DefaultCamundaWorker
    {
        private readonly IExternalTaskClient _externalTaskClient;
        private readonly IFetchAndLockRequestProvider _fetchAndLockRequestProvider;
        private readonly WorkerEvents _workerEvents;
        private readonly IServiceProvider _serviceProvider;
        private readonly WorkerHandlerDescriptor _workerHandlerDescriptor;
        private readonly IEndpointProvider _endpointProvider;

        public DefaultCamundaWorker(IServiceProvider serviceProvider, CamundaWorkerServices workerServices)
        {
            _serviceProvider = serviceProvider;
            
            _externalTaskClient = serviceProvider.GetRequiredService<IExternalTaskClient>();
            
            _fetchAndLockRequestProvider = workerServices.FetchAndLockRequestProvider;
            _workerEvents = workerServices.WorkerEvents;
            _workerHandlerDescriptor = workerServices.WorkerHandlerDescriptor;
            _endpointProvider = workerServices.EndpointProvider;
        }

        public async Task RunAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                var externalTasks = await SelectAsync(cancellationToken);

                if (externalTasks != null && externalTasks.Count != 0)
                {
                    var tasks = new Task[externalTasks.Count];
                    var i = 0;
                    foreach (var externalTask in externalTasks)
                    {
                        tasks[i++] = Task.Run(
                            () => ProcessExternalTaskAsync(externalTask, cancellationToken), cancellationToken);
                    }

                    await Task.WhenAll(tasks);
                }

            }
        }

        private async Task<List<ExternalTask>?> SelectAsync(CancellationToken cancellationToken)
        {
            try
            {
                LogHelper.LogWaiting(null);
                var fetchAndLockRequest = _fetchAndLockRequestProvider.GetRequest();
                var externalTasks = await _externalTaskClient.FetchAndLockAsync(fetchAndLockRequest, cancellationToken);
                LogHelper.LogLocked(null, externalTasks.Count);
                return externalTasks;
            }
            catch (Exception e) when (!cancellationToken.IsCancellationRequested)
            {
                LogHelper.LogFailedLocking(null, e);
                return null;
            }
        }

        private async Task ProcessExternalTaskAsync(ExternalTask externalTask, CancellationToken cancellationToken)
        {
            using var scope = _serviceProvider.CreateScope();
            var context = new ExternalTaskContext(
                externalTask,
                _externalTaskClient,
                _endpointProvider,
                scope.ServiceProvider,
                cancellationToken
            );

            try
            {
                await _workerHandlerDescriptor.ExternalTaskDelegate(context);
            }
            catch (Exception e)
            {
                LogHelper.LogFailedExecution(null, externalTask.Id, e);
            }
        }

        [ExcludeFromCodeCoverage]
        private static class LogHelper
        {
            private static readonly Action<ILogger, Exception?> Waiting =
                LoggerMessage.Define(
                    LogLevel.Debug,
                    new EventId(0),
                    "Waiting for external task"
                );

            private static readonly Action<ILogger, Exception?> Locked =
                LoggerMessage.Define<string>(
                    LogLevel.Debug,
                    new EventId(0),
                    "Locked external tasks"
                );

            private static readonly Action<ILogger, Exception?> FailedLocking =
                LoggerMessage.Define<string>(
                    LogLevel.Warning,
                    new EventId(0),
                    "Failed locking of external tasks. Reason: \"{Reason}\""
                );

            private static readonly Action<ILogger, Exception?> FailedExecution =
                LoggerMessage.Define<string>(
                    LogLevel.Warning,
                    new EventId(0),
                    "Failed execution of task {Id}"
                );

            public static void LogWaiting(ILogger logger)
            {
                if (logger.IsEnabled(LogLevel.Debug))
                {
                    Waiting(logger, null);
                }
            }

            public static void LogLocked(ILogger logger, int count)
            {
                if (logger.IsEnabled(LogLevel.Debug))
                {
                    Locked(logger, null);
                }
            }

            public static void LogFailedLocking(ILogger logger, Exception e)
            {
                if (logger.IsEnabled(LogLevel.Warning))
                {
                    FailedLocking(logger, null);
                }
            }

            public static void LogFailedExecution(ILogger logger, string externalTaskId, Exception e)
            {
                if (logger.IsEnabled(LogLevel.Warning))
                {
                    FailedExecution(logger, null);
                }
            }
        }
    }

    public class WorkerHandlerDescriptor
    {
        public async Task ExternalTaskDelegate(ExternalTaskContext context)
        {
            throw new NotImplementedException();
        }
    }

    public class WorkerEvents
    {
    }

    public interface IFetchAndLockRequestProvider
    {
        object GetRequest();
    }

    public class ExternalTaskContext
    {
        public ExternalTaskContext(ExternalTask externalTask, IExternalTaskClient externalTaskClient, IEndpointProvider endpointProvider, IServiceProvider scopeServiceProvider, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }

    public class ExternalTask
    {
        public string Id { get; set; }
    }

    public interface IEndpointProvider
    {
    }

    public class LoggerMessage
    {
        public static Action<ILogger, Exception?> Define<T>(LogLevel warning, EventId eventId, T failedLockingOfExternalTasksReasonReason)
        {
            throw new NotImplementedException();
        }
    }

    public class EventId
    {
        public EventId(int id)
        {
            
        }
    }

    public enum LogLevel
    {
        Debug,
        Warning
    }

    public interface ILogger
    {
        bool IsEnabled(object debug);
    }

    public interface IExternalTaskClient
    {
        Task<List<ExternalTask>?> FetchAndLockAsync(object fetchAndLockRequest, CancellationToken cancellationToken);
    }

    public class CamundaWorkerServices
    {
        public IFetchAndLockRequestProvider FetchAndLockRequestProvider { get; set; }
        public IEndpointProvider EndpointProvider { get; set; }
        public WorkerEvents WorkerEvents { get; set; }
        public WorkerHandlerDescriptor WorkerHandlerDescriptor { get; set; }
    }
}
