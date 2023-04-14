namespace KingdomStrategy.Domain.Resources;

public enum ConsumePoolResult
{
    None = 0,
    NotEnoughResources = 1,
    
    Ok = 100,
}

public enum ConsumeResult
{
    None = 0,
    NotEnoughQuantity = 1,
    Ok = 2,
}

public abstract class ResourceManager : Any
{
    private readonly Dictionary<ResourceType, Resource> _resourceByType;

    protected ResourceManager(IEnumerable<Resource> items)
    {
        _resourceByType = items
            .ToDictionary(c => c.Type, c => c);

        ConsumeResult = ConsumeResult.None;
        ConsumePoolResult = ConsumePoolResult.None;
    }

    public ConsumePoolResult ConsumePoolResult { get; private set; }
    public ConsumeResult ConsumeResult { get; private set; }
    
    //предусловие, достаточно ресурсов для потребления
    //постусловие, ресурсы поглощены
    public async Task ConsumePool(ResourcePool requested)
    {
        if (!CanConsume(requested))
        {
            ConsumePoolResult = ConsumePoolResult.NotEnoughResources;
            return;
        }
        
        ConsumePoolResult = ConsumePoolResult.Ok;
        throw new NotImplementedException();
    }

    //постусловие, объем ресурса увеличен 
    public async Task Put(Resource resource)
    {
        throw new NotImplementedException();
    }

    //предусловие, достаточно ресурса для потребления
    //постусловие, ресурс поглощен
    public async Task Consume(Resource requested)
    {
        if (!CanConsume(requested))
        {
            ConsumeResult = ConsumeResult.NotEnoughQuantity;
            return;
        }

        ConsumeResult = ConsumeResult.Ok;
        throw new NotImplementedException();
    }

    private Resource FindByType(ResourceType resourceType)
    {
        var foundResource = _resourceByType[resourceType];
        return foundResource;
    }
    
    private bool CanConsume(ResourcePool requested)
    {
        throw new NotImplementedException();
    }
    
    private bool CanConsume(Resource requested)
    {
        throw new NotImplementedException();
    }
    
    
}