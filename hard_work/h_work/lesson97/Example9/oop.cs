public interface IStorageService
{
    Task<bool> Exists(long id);
}

public class DbService : IStorageService
{
    public Task<bool> Exists(long id)
    {
        throw new NotImplementedException();
    }
}


public class CachedDbService(IStorageService _wrappedService) : IStorageService
{
    public Task<bool> Exists(long id)
    {
        throw new NotImplementedException();
    }
}