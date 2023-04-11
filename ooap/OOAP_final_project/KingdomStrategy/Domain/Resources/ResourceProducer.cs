namespace KingdomStrategy.Domain.Resources;

public abstract class ResourceProducer
{
    public abstract Task<Resource> Produce();
}