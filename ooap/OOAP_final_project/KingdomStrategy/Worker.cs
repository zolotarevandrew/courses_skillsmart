using KingdomStrategy.Domain;
using KingdomStrategy.Domain.Buildings;
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
        var storage = _factory.Get<LumberMillState>(kingdomRef);

        var state = new LumberMillState(
            new Level(1), 
            new Wood(new ResourceQuantity(5)), 
            new ResourceQuantity(20));

        var lumberMill = new LumberMill(storage, state);
        await lumberMill.Modernize();
        await lumberMill.Modernize();

        var storage2 = _factory.Get<GoldMineState>(kingdomRef);

        var state2 = new GoldMineState(
            new Level(1), 
            new Gold(new ResourceQuantity(5)), 
            new ResourceQuantity(20));

        var goldMine = new GoldMine(storage2, state2);
        await goldMine.Modernize();
        
        
        var state3 = new GoldMineState(
            new Level(2), 
            new Gold(new ResourceQuantity(11)), 
            new ResourceQuantity(20));

        var goldMine2 = new GoldMine(storage2, state3);
        await goldMine2.Modernize();


        await Task.Delay(10000000, stoppingToken);
    }
}