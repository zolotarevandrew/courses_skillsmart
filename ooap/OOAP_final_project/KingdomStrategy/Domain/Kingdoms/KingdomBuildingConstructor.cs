using KingdomStrategy.Domain.Buildings;
using KingdomStrategy.Domain.Buildings.Constructors;
using KingdomStrategy.Domain.Buildings.Implementations;
using KingdomStrategy.Domain.Resources;
using KingdomStrategy.Domain.Resources.Implementations;
using KingdomStrategy.Infrastructure;
using KingdomStrategy.Infrastructure.Kingdoms;

namespace KingdomStrategy.Domain.Kingdoms;

public class KingdomBuildingConstructor : BuildingConstructor
{
    private readonly KingdomRef _kingdomRef;
    private readonly KingdomBaseStorageFactory _baseStorageFactory;
    
    private Building _constructed;

    public KingdomBuildingConstructor(KingdomRef kingdomRef, KingdomBaseStorageFactory baseStorageFactory, IMediator mediator) : base(mediator)
    {
        _kingdomRef = kingdomRef;
        _baseStorageFactory = baseStorageFactory;
    }
    
    public override List<BuildingConstructionCost> GetAllConstructionsCosts()
    {
        return new List<BuildingConstructionCost>
        {
            new BuildingConstructionCost(BuildingType.GoldMine, new ResourcePool(new List<Resource>
            {
                new Wood(new ResourceQuantity(10)),
                new Stone(new ResourceQuantity(10)),
            })),
            new BuildingConstructionCost(BuildingType.LumberMill, new ResourcePool(new List<Resource>
            {
                new Wood(new ResourceQuantity(10)),
                new Stone(new ResourceQuantity(20)),
            })),
        };
    }

    public override List<BuildingModernizationCost> GetAllModernizationsCost()
    {
        return new List<BuildingModernizationCost>
        {
            new BuildingModernizationCost(BuildingType.GoldMine, new ResourcePool(new List<Resource>
            {
                new Wood(new ResourceQuantity(1)),
                new Stone(new ResourceQuantity(2)),
            })),
            new BuildingModernizationCost(BuildingType.LumberMill, new ResourcePool(new List<Resource>
            {
                new Wood(new ResourceQuantity(1)),
                new Stone(new ResourceQuantity(2)),
            })),
        };
    }

    public override Building GetConstructed()
    {
        return _constructed;
    }

    protected override async Task Construct(BuildingType type)
    {
        switch (type)
        {
            case BuildingType.GoldMine:
            {
                var store = _baseStorageFactory.Get<GoldMineState>(_kingdomRef);
                var state = new GoldMineState(
                    new Level(1), 
                    new Gold(new ResourceQuantity(5)), 
                    new ResourceQuantity(20));
                _constructed = new GoldMine(store, state);
                await store.Save(state);
                return;
            }
            case BuildingType.LumberMill:
            {
                var store = _baseStorageFactory.Get<LumberMillState>(_kingdomRef);
                var state = new LumberMillState(
                    new Level(1), 
                    new Wood(new ResourceQuantity(5)), 
                    new ResourceQuantity(20));
                _constructed = new LumberMill(store, state);
                await store.Save(state);
                return;
            }
            default:
                throw new ArgumentOutOfRangeException(nameof(type), type, null);
        }
    }
}