

namespace h_work.lesson13.example1;

public class InternalRequestContext
{

}

public class CddParameterValueChangedAuditMessage
{

}

public class DossierQuestionnaireEditionContext
{
    public Guid CompanyId { get; }
    public List<DataSource> DataSources { get; }
    public bool IsChanged { get; set; }

    public List<CddParameterValueChangedAuditMessage> ValueChangedLogsToStore = new List<CddParameterValueChangedAuditMessage>();
    public DossierQuestionnaireEditionContext(InternalRequestContext context)
    {

    }

    public void TryAddData(string name, object data)
    {
        throw new NotImplementedException();
    }
}

public interface IDistributedLockFactory
{
    Task<IDistributedLock> AcquireLockAsync(string key, TimeSpan lockDuration);
}

public interface IDistributedLock : IDisposable
{

}

public interface IDbConnector
{
    Task<IDbConnection> OpenConnection(CancellationToken none);
}
public interface IDbTransaction : IDisposable
{
    void Commit();
    void Rollback();
}

public interface IDbConnection : IDisposable
{
    IDbTransaction BeginTransaction();
}

public interface IDataSourceStorageService
{
    Task Upsert(IDbConnection connection, IDbTransaction transaction, List<DataSource> dataSources);
}

public class DataSource
{

}

public interface IPublisher
{
    Task Publish<TMessage>(TMessage message);
}

public class Before
{
    private readonly IDistributedLockFactory _lockFactory;
    private readonly IDbConnector _dbConnector;
    private readonly IDataSourceStorageService _dataSourceStorageService;
    private readonly IPublisher _publisher;

    public Before(
        IDistributedLockFactory lockFactory,
        IDbConnector dbConnector,
        IDataSourceStorageService dataSourceStorageService, IPublisher publisher)
    {
        _lockFactory = lockFactory;
        _dbConnector = dbConnector;
        _dataSourceStorageService = dataSourceStorageService;
        _publisher = publisher;
    }

    public async Task Do()
    {
            var requestContext = new InternalRequestContext
            {

            };
            var context = new DossierQuestionnaireEditionContext(requestContext);
            context.TryAddData(nameof(DateTime.UtcNow), DateTime.UtcNow);
        

            var lockKey = "CompanyId_" + context.CompanyId.ToString();
            using (await _lockFactory.AcquireLockAsync(lockKey, TimeSpan.FromSeconds(30)))
            {
                using (var dbConnection = await _dbConnector.OpenConnection(CancellationToken.None))
                using (var dbTransaction = dbConnection.BeginTransaction())
                {
                    try
                    {
                        //Here was logic with transactions

                         await _dataSourceStorageService.Upsert(dbConnection, dbTransaction, context.DataSources);

                        dbTransaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        dbTransaction.Rollback();
                        throw;
                    }
                }
            }

            var logTasks = context
                .ValueChangedLogsToStore
                .Select(storeLogMessage => _publisher.Publish(storeLogMessage));


            //other logic to other tasks (events) was  here (just not mentioned)


            await Task.WhenAll(logTasks);
    }
}