namespace h_work.lesson65.example2;

public interface IDbConnector
{
    Task<DbConnection> OpenConnection(CancellationToken none);
}

public abstract class DbConnection : IDisposable
{
    public void Dispose()
    {
    }

    public DbTransaction BeginTransaction()
    {
        return new DbTransaction();
    }
}

public class DbTransaction : IDisposable
{
    public void Dispose()
    {
    }

    public void Commit()
    {
        
    }

    public void Rollback()
    {
        
    }
}

public interface IDataSourceStorageService
{
    
}

public class Before
{
    private readonly IDataSourceStorageService _dataSourceStorageService;
    private readonly IDbConnector _dbConnector;
    
    public async Task Value()
    {
        using var dbConnection = await _dbConnector.OpenConnection(CancellationToken.None);
        using var dbTransaction = dbConnection.BeginTransaction();
        try
        {
            //await _dataSourceStorageService.Upsert(dbConnection, dbTransaction, sourcesInStorage);
            dbTransaction.Commit();
        }
        catch (Exception e)
        {
            dbTransaction.Rollback();
            throw;
        }
    }
}