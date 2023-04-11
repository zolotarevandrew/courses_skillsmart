namespace KingdomStrategy.Domain.Resources;


public abstract class ResourceManager : Any
{
    public abstract Task Acquire(Resource resource);
    public abstract Task Consume(Resource resource);
    public abstract Task Transfer(Resource resource, ResourceManager otherManager);
}