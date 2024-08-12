namespace h_work.lesson65.example2;


public delegate Task DbTransactionDelegate(IDbConnection connection, IDbTransaction transaction, CancellationToken token);

public interface IDbConnectorV2
{
    Task RunInTransaction(DbTransactionDelegate action);
}

public interface IDbConnection
{
    
}

public interface IDbTransaction
{
    
}

public class DbConnectionV2 : IDbConnection, IDisposable
{
    public void Dispose()
    {
    }

    public DbTransactionV2 BeginTransaction()
    {
        return new DbTransactionV2();
    }
}

public class DbTransactionV2 : IDbTransaction, IDisposable
{

    public void Commit()
    {
        
    }

    public void Rollback()
    {
        
    }

    public void Dispose()
    {
    }
}

public class DbConnector : IDbConnectorV2
{
    public async Task RunInTransaction(DbTransactionDelegate action)
    {
        var token = CancellationToken.None;
        using var dbConnection = new DbConnectionV2();
        using var dbTransaction = dbConnection.BeginTransaction();
        await action(dbConnection, dbTransaction, token);
        dbTransaction.Commit();
    }
}


public class After
{
    
}