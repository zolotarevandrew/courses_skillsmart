using KingdomStrategy.Domain;
using KingdomStrategy.Domain.Armies.Implementations;
using KingdomStrategy.Domain.Armies.Troops;
using KingdomStrategy.Domain.Kingdoms;
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
        var store = _factory.Get<TroopState>(kingdomRef);

        var state = new TroopState(new Health(500), new TroopSize(20), new AttackPower(20), new DefensePower(10),
            new Level(1), TroopType.Archers);
        var state2 = new TroopState(new Health(500), new TroopSize(20), new AttackPower(20), new DefensePower(10),
            new Level(1), TroopType.Cavalry);
        
        var archers = new Archers(store, state);
        var cavalry = new Cavalry(store, state2);

        await cavalry.Attack(archers);

        var army = new KingdomArmy(new TroopList(new List<Troop>
        {
            archers,
            cavalry
        }));

    }
}