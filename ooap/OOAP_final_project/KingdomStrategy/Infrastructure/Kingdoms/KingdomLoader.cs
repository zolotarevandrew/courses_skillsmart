using KingdomStrategy.Domain.Armies.Implementations;
using KingdomStrategy.Domain.Armies.Troops;
using KingdomStrategy.Domain.Buildings;
using KingdomStrategy.Domain.Buildings.Implementations;
using KingdomStrategy.Domain.Kingdoms;
using KingdomStrategy.Domain.Resources;
using KingdomStrategy.Infrastructure.Storage;
using KingdomStrategy.Infrastructure.Storage.Interfaces;

namespace KingdomStrategy.Infrastructure.Kingdoms;

public class KingdomLoader
{
    private readonly KingdomStorage _kingdomStorage;
    private readonly KingdomBaseStorageFactory _kingdomBaseStorageFactory;
    private readonly KingdomMediatorFactory _kingdomMediatorFactory;

    public KingdomLoader(
        KingdomStorage kingdomStorage, 
        KingdomBaseStorageFactory kingdomBaseStorageFactory, KingdomMediatorFactory kingdomMediatorFactory)
    {
        _kingdomStorage = kingdomStorage;
        _kingdomBaseStorageFactory = kingdomBaseStorageFactory;
        _kingdomMediatorFactory = kingdomMediatorFactory;
    }

    public async Task<List<KingdomRef>> GetAllRefs()
    {
        var kingdomStates = await _kingdomStorage.GetAll();
        return kingdomStates
            .Select(c => c.Ref)
            .ToList();
    }

    public async Task<Kingdom?> GetByRef(KingdomRef @ref)
    {
        var kingdomState = await _kingdomStorage.GetByRef(@ref);
        if (kingdomState == null) return null;

        var relatedStates = await _kingdomStorage.GetRelatedState(@ref);
        
        var resourceManager = await GetResourceManager(@ref, relatedStates);
        var buildingConstructor = new KingdomBuildingConstructor(@ref, _kingdomBaseStorageFactory);
        var army = await GetArmy(@ref, relatedStates);
        var buildings = await GetBuildings(@ref, relatedStates);
        var kingdom = new Kingdom(kingdomState, army, resourceManager, buildingConstructor, buildings);

        return kingdom;
    }

    private async Task<List<Building>> GetBuildings(KingdomRef @ref, List<ByKingdomState> relatedStates)
    {
        var buildings = new List<Building>();
        
        var lumberMillStorage = _kingdomBaseStorageFactory.Get<LumberMillState>(@ref);
        var lumberMillsState = await LoadStateByType(lumberMillStorage, relatedStates);
        foreach (var lumberMill in lumberMillsState)
        {
            buildings.Add(new LumberMill(lumberMillStorage, lumberMill));
        }
        
        var goldMineStorage = _kingdomBaseStorageFactory.Get<GoldMineState>(@ref);
        var goldMinesState = await LoadStateByType(goldMineStorage, relatedStates);
        foreach (var goldMine in goldMinesState)
        {
            buildings.Add(new GoldMine(goldMineStorage, goldMine));
        }
        
        return buildings;
    }

    private async Task<KingdomArmy> GetArmy(KingdomRef @ref, List<ByKingdomState> relatedStates)
    {
        var storage = _kingdomBaseStorageFactory.Get<TroopState>(@ref);
        var troopStates = await LoadStateByType(storage, relatedStates);
        var troops = new List<Troop>();
        var mediator = _kingdomMediatorFactory.Get(@ref);
        foreach (var troopState in troopStates)
        {
            switch (troopState.Type)
            {
                case TroopType.Archers:
                    troops.Add(new Archers(mediator, storage, troopState));
                    break;
                case TroopType.Cavalry:
                    troops.Add(new Cavalry(mediator, storage, troopState));
                    break;
                case TroopType.Infantry:
                    troops.Add(new Infantry(mediator, storage, troopState));
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        var army = new KingdomArmy(new TroopList(troops));
        return army;
    }

    private async Task<KingdomResourceManager> GetResourceManager(KingdomRef @ref, List<ByKingdomState> relatedStates)
    {
        var resourceStorage = _kingdomBaseStorageFactory.Get<ResourceManagerState>(@ref);
        var resourceManagerStates = await LoadStateByType(resourceStorage, relatedStates);
        var resourceManagerState = resourceManagerStates.FirstOrDefault();
        var resourceManager = new KingdomResourceManager(resourceStorage, resourceManagerState);
        return resourceManager;
    }

    private async Task<List<TState>> LoadStateByType<TState>(
        KingdomBaseStorage<TState> storage, 
        List<ByKingdomState> relatedStates) 
        where TState: State
    {
        var resourceManagerState = relatedStates.Where(c => c.StateType == typeof(TState).Name);
        return await storage.Load(resourceManagerState.Select(c => c.StateId).ToList());
    }
}