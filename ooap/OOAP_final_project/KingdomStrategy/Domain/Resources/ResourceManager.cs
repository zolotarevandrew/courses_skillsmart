namespace KingdomStrategy.Domain.Resources;


public abstract class ResourceManager : Any
{
    protected List<Resource> Resources;
    protected ResourceManager(List<Resource> resources)
    {
        Resources = resources;
    }
    
    //предусловие, достаточно ресурсов для потребления
    //постусловие, количество запрошенных ресурсов уменьшено
    public async Task ConsumePool(RequestedResourcePool pool)
    {
        foreach (var resource in pool.Items)
        {
            await Consume(resource);
            
            if (ConsumeResult == 0) continue;
            
            ConsumePoolResult = 1;
            return;
        }

        ConsumePoolResult = 0;
    }

    public async Task Pick(Resource resource)
    {
        var foundResource = FindByType(resource.Type);
        foundResource.AddQuantity(resource.Quantity);

        PickResult = 0;
    }
    
    public async Task Consume(Resource resource)
    {
        var foundResource = FindByType(resource.Type);
        var consumed = foundResource.ConsumeQuantity(resource.Quantity);

        ConsumeResult = consumed ? 0 : 1;
    }

    public async Task<List<Resource>> GetAll()
    {
        return Resources;
    }
    
    private Resource FindByType(ResourceType resourceType)
    {
        var foundResource = Resources.SingleOrDefault(c => c.Type == resourceType);
        return foundResource;
    }

    public int ConsumePoolResult { get; protected set; }
    public int ConsumeResult { get; protected set; }
    public int PickResult { get; protected set; }
}