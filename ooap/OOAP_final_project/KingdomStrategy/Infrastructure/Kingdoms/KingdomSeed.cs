using KingdomStrategy.Domain;
using KingdomStrategy.Domain.Armies.Implementations;
using KingdomStrategy.Domain.Armies.Troops;
using KingdomStrategy.Domain.Buildings;
using KingdomStrategy.Domain.Buildings.Constructors;
using KingdomStrategy.Domain.Kingdoms;
using KingdomStrategy.Domain.Kingdoms.Ratings;
using KingdomStrategy.Domain.Resources;
using KingdomStrategy.Domain.Resources.Implementations;
using KingdomStrategy.Infrastructure.Storage;
using KingdomStrategy.UseCases;

namespace KingdomStrategy.Infrastructure.Kingdoms;

public class KingdomSeed
{
    private readonly KingdomStorage _kingdomStorage;
    private readonly KingdomBaseStorageFactory _kingdomBaseStorageFactory;
    private readonly KingdomRatingStorage _ratingStorage;
    private readonly ILogWriter _logWriter;
    public KingdomSeed(KingdomStorage kingdomStorage, KingdomBaseStorageFactory kingdomBaseStorageFactory, KingdomRatingStorage ratingStorage, ILogWriter logWriter)
    {
        _kingdomStorage = kingdomStorage;
        _kingdomBaseStorageFactory = kingdomBaseStorageFactory;
        _ratingStorage = ratingStorage;
        _logWriter = logWriter;
    }

    public async Task Seed()
    {
        _logWriter.Write("Seeding data...");
        
        await CreateKingdomByNam("Hoappa - 1");
        await CreateKingdomByNam("Borroca - 2");
        await CreateKingdomByNam("Trefecta - 3");
        
        _logWriter.Write("Seeding data finished.");
    }

    private async Task CreateKingdomByNam(string name)
    {
        var kingdomState = new KingdomState(name);
        var res = await _kingdomStorage.Store(kingdomState);
        if (!res) return;

        var kingdomRef = kingdomState.Ref;

        var store = _kingdomBaseStorageFactory.Get<TroopState>(kingdomRef);
        var archers = new TroopState(new Health(500), new TroopSize(20), new AttackPower(20), new DefensePower(10),
            new Level(1), TroopType.Archers);
        var cavalry = new TroopState(new Health(500), new TroopSize(20), new AttackPower(20), new DefensePower(10),
            new Level(1), TroopType.Cavalry);
        var infantry = new TroopState(new Health(500), new TroopSize(20), new AttackPower(20), new DefensePower(10),
            new Level(1), TroopType.Infantry);

        await store.Save(archers);
        await store.Save(cavalry);
        await store.Save(infantry);

        await _ratingStorage.Store(new KingdomRating(kingdomRef, 0, DateTime.UtcNow));

        var storage = _kingdomBaseStorageFactory.Get<ResourceManagerState>(kingdomRef);
        var state = new ResourceManagerState(new List<Resource>
        {
            new Food(new ResourceQuantity(100)),
            new Gold(new ResourceQuantity(300)),
            new Stone(new ResourceQuantity(300)),
            new Wood(new ResourceQuantity(500))
        });

        await storage.Save(state);
    }
}