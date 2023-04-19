using KingdomStrategy.Infrastructure.Storage.Interfaces;

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

public class ResourceManagerState : State
{
    private Dictionary<ResourceType, Resource> _resourceByType;
    
    private IEnumerable<Resource> _resources;

    public ResourceManagerState(IEnumerable<Resource> resources)
    {
        _resources = resources;
        _resourceByType = resources.ToDictionary(c => c.Type, c => c);
    }

    public Resource Get(ResourceType type)
    {
        return _resourceByType[type];
    }

    public IEnumerable<ResourceType> Available => _resourceByType.Keys;
}

public abstract class ResourceManager : StateStorable<ResourceManagerState>
{

    protected ResourceManager(ResourceManagerState state) : base(state) 
    {
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

        foreach (var key in State.Available)
        {
            await Consume(requested.Get(key));
        }

        await SaveState();
        
        ConsumePoolResult = ConsumePoolResult.Ok;
    }

    //постусловие, объем ресурса увеличен 
    public async Task Put(Resource resource)
    {
        var foundResource = State.Get(resource.Type);
        foundResource.AddQuantity(resource.Quantity);
        
        await SaveState();
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

        var resource = State.Get(requested.Type);
        resource.ConsumeQuantity(requested.Quantity);
        ConsumeResult = ConsumeResult.Ok;
        
        await SaveState();
    }

    private bool CanConsume(ResourcePool requested)
    {
        foreach (var type in State.Available)
        {
            var resource = requested.Get(type);
            if (!CanConsume(resource)) return false;
        }

        return true;
    }
    
    private bool CanConsume(Resource requested)
    {
        var consumed = State.Get(requested.Type);
        return consumed.CanConsume(requested.Quantity);
    }

}