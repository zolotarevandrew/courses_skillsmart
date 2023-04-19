using KingdomStrategy.Domain.Kingdoms;
using KingdomStrategy.Domain.Kingdoms.Implementations;
using KingdomStrategy.Domain.Resources;
using KingdomStrategy.Domain.Resources.Implementations;
using KingdomStrategy.Infrastructure.Kingdoms;
using KingdomStrategy.Infrastructure.Storage.Mappings;

namespace KingdomStrategy;

public class Worker : BackgroundService
{
    private readonly KingdomBaseStorageFactory _factory; 

    public Worker(KingdomBaseStorageFactory factory)
    {
        _factory = factory;
    }
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var kingdomRef = new KingdomRef("1", "2");
        var storage = _factory.Get<ResourceManagerState>(kingdomRef);

        var state = new ResourceManagerState(new List<Resource>
        {
            new Food(new ResourceQuantity(1)),
            new Gold(new ResourceQuantity(3)),
            new Stone(new ResourceQuantity(3)),
            new Wood(new ResourceQuantity(5))
        });
        
        await storage.Save(state);

        var restoredState = await storage.Get();

        await Task.Delay(10000000, stoppingToken);
    }
}