

using System.Diagnostics;
using Microsoft.Extensions.Logging;

namespace h_work.lesson13.example2;

public interface IOperationLogger
{
    Task Log(string message, LogOperationDelegate @delegate);
}

public delegate Task LogOperationDelegate(OperationLogData operationData);

public class OperationLogData
{
    private readonly List<(string, object)> _values;

    public OperationLogData()
    {
        _values = new List<(string, object)>();
    }
    public void Add(string key, object value)
    {
        _values.Add((key, value));
    }

    public string Get()
    {
        //пускай для обучения будет так, тут надо разбираться как лучше логировать 
        return string.Join(", ", _values.Select(c => c.Item1 + " = " + c.Item2));
    }
}

public delegate Task OnboardingLogOperationDelegate(IOnboardingContext context, OperationLogData operationData);

public static class Extensions
{
    //отделяем логику онбординга от основного OperationLogger, через создание кастомных делегатов (возможно будет лучше завести отдельную абстракцию далее)
    public static LogOperationDelegate WithOnboardingLog(this IOnboardingContext context, OnboardingLogOperationDelegate @delegate)
    {
        async Task OnboardingLogOperation(OperationLogData logData)
        {
            logData.Add("OnboardingId", context.Id);
            await @delegate(context, logData);
        }
        return OnboardingLogOperation;
    }
    
}

public class OperationLogger : IOperationLogger
{
    private readonly ILogger<OperationLogger> _logger;

    public OperationLogger(ILogger<OperationLogger> logger)
    {
        _logger = logger;
    }
    public async Task Log(string message, LogOperationDelegate @delegate)
    {
        var watch = Stopwatch.StartNew();
        var operationData = new OperationLogData();
        try
        {
            await @delegate(operationData);
        }
        catch (Exception ex)
        {
            watch.Stop();
            LogError(ex, operationData, message, watch.ElapsedMilliseconds);
            throw;
        }
        finally
        {
            watch.Stop();
            LogInfo(operationData, message, watch.ElapsedMilliseconds);
        }
    }

    private void LogInfo(OperationLogData operationData, string message, long watchElapsedMilliseconds)
    {
        _logger.LogInformation(message + " " + operationData.Get() + " elapsed: " + watchElapsedMilliseconds);
    }
    
    private void LogError(Exception ex, OperationLogData operationData, string message, long watchElapsedMilliseconds)
    {
        _logger.LogError(ex, message + " " + operationData.Get() + " elapsed: " + watchElapsedMilliseconds);
    }
}

public class ExampleUsing
{
    private readonly IOperationLogger _operationLogger;

    public ExampleUsing(IOperationLogger operationLogger)
    {
        _operationLogger = operationLogger;
    }

    public async Task Test()
    {
        IOnboardingContext context = null;
        await _operationLogger.Log("CustomMessage", context.WithOnboardingLog(LogInternal));
    }

    async Task LogInternal(IOnboardingContext context, OperationLogData operationData)
    {
        operationData.Add("test", true);
        await Task.CompletedTask;
    }
}