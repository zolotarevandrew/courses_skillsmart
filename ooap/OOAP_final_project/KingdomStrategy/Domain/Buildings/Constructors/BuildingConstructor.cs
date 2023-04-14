using KingdomStrategy.Domain.Resources;

namespace KingdomStrategy.Domain.Buildings.Constructors;

public enum ModernizeResult
{
    None = 0,
    NotSupportedBuilding = 1,
    NotEnoughResources = 2,
    
    Ok = 100,
}

public enum ConstructResult
{
    None = 0,
    NotSupportedBuilding = 1,
    NotEnoughResources = 2,
    
    Ok = 100
}
public abstract class BuildingConstructor : Any
{
    public ModernizeResult ModernizeResult { get; private set; }
    public ConstructResult ConstructResult { get; private set; }
    
    //предусловие, возможно создать такое здание
    //предусловие, достаточно ресурсов для создания
    //постусловие, постройка здания начата
    public async Task Construct(BuildingConstructionRequest request)
    {
        var cost = GetConstructionCost(request.Type);
        if (cost == null)
        {
            ConstructResult = ConstructResult.NotSupportedBuilding;
            return;
        }
        
        await request.ResourceManager.ConsumePool(cost.Resources);
        if (request.ResourceManager.ConsumePoolResult == ConsumePoolResult.NotEnoughResources)
        {
            ConstructResult = ConstructResult.NotEnoughResources;
            return;
        }
        
        ConstructResult = ConstructResult.Ok;
    }

    //предусловие, возможно модернизировать такое здание
    //предусловие, достаточно ресурсов для модернизации
    //постусловие, здание модернизировано
    public async Task Modernize(BuildingModernizationRequest request)
    {
        var cost = GetModernizationCost(request.Building.Type);
        if (cost == null)
        {
            ModernizeResult = ModernizeResult.NotSupportedBuilding;
            return;
        }
        
        await request.ResourceManager.ConsumePool(cost.Resources);
        if (request.ResourceManager.ConsumePoolResult == ConsumePoolResult.NotEnoughResources)
        {
            ModernizeResult = ModernizeResult.NotEnoughResources;
            return;
        }
        
        await request.Building.Modernize();
        ModernizeResult = ModernizeResult.Ok;
    }
    
    public abstract List<BuildingConstructionCost> GetAllConstructionsCosts();
    public abstract List<BuildingModernizationCost> GetAllModernizationsCost();

    private BuildingConstructionCost? GetConstructionCost(BuildingType buildingType)
    {
        throw new NotImplementedException();
    }

    private BuildingModernizationCost? GetModernizationCost(BuildingType buildingType)
    {
        throw new NotImplementedException();
    }
}