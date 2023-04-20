using KingdomStrategy.Domain;
using KingdomStrategy.Domain.Buildings;
using KingdomStrategy.Domain.Buildings.Constructors;
using KingdomStrategy.Domain.Buildings.Implementations;
using KingdomStrategy.Domain.Kingdoms;
using KingdomStrategy.Domain.Resources;
using KingdomStrategy.Domain.Resources.Implementations;
using KingdomStrategy.Infrastructure.Kingdoms;

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
        var constructor = new KingdomBuildingConstructor(kingdomRef, _factory);
        
        var storage = _factory.Get<ResourceManagerState>(kingdomRef);
        var state = new ResourceManagerState(new List<Resource>
        {
            new Food(new ResourceQuantity(100)),
            new Gold(new ResourceQuantity(300)),
            new Stone(new ResourceQuantity(300)),
            new Wood(new ResourceQuantity(500))
        });

        var resourceManager = new KingdomResourceManager(storage, state);
        await storage.Save(state);

        await constructor.Construct(new BuildingConstructionRequest(BuildingType.GoldMine, resourceManager));
        await constructor.Construct(new BuildingConstructionRequest(BuildingType.LumberMill, resourceManager));

        await Task.CompletedTask;
    }
}