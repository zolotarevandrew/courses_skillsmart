namespace KingdomStrategy.Domain.Resources;


public abstract class ResourceManager : Any
{
    public abstract Task<List<Resource>> GetAll();
    //предусловие, достаточно ресурсов для потребления
    //постусловие, количество запрошенных ресурсов уменьшено
    public abstract Task ConsumeRequested(RequestedResourcePool pool);

    public int ConsumePoolResult { get; protected set; }
}