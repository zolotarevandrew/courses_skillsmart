using KingdomStrategy.Domain.Resources;
using KingdomStrategy.Infrastructure;

namespace KingdomStrategy.Domain.Buildings.Constructors;

public enum ModernizeResult
{
    None = 0,
    NotSupportedBuilding = 1,
    NotEnoughResources = 2,
    Failed = 3,
    
    Ok = 100,
}

public enum ConstructResult
{
    None = 0,
    NotSupportedBuilding = 1,
    NotEnoughResources = 2,
    
    Ok = 100
}

public enum GetConstructedResult
{
    None = 0,
    NotReady = 1,
    Ok = 100
}
public abstract class BuildingConstructor : Any
{
    private readonly IMediator _mediator;
    public ModernizeResult ModernizeResult { get; private set; }
    public ConstructResult ConstructResult { get; private set; }
    public GetConstructedResult GetConstructedResult { get; private set; }

    protected BuildingConstructor(IMediator mediator)
    {
        _mediator = mediator;
        ModernizeResult = ModernizeResult.None;
        ConstructResult = ConstructResult.None;
    }
    
    //предусловие, возможно создать такое здание
    //предусловие, достаточно ресурсов для создания
    //постусловие, здание построено
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

        await Construct(request.Type);
        await _mediator.Publish(new BuildingConstructedEvent());
        
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
        if (request.ResourceManager.ConsumePoolResult != ConsumePoolResult.Ok)
        {
            ModernizeResult = ModernizeResult.NotEnoughResources;
            return;
        }
        
        await request.Building.Modernize();
        
        if (request.Building.ModernizeResult != Buildings.ModernizeResult.Ok)
        {
            ModernizeResult = ModernizeResult.Failed;
            return;
        }
        ModernizeResult = ModernizeResult.Ok;
        await _mediator.Publish(new BuildingModernizedEvent());
    }
    
    public abstract List<BuildingConstructionCost> GetAllConstructionsCosts();
    public abstract List<BuildingModernizationCost> GetAllModernizationsCost();
    
    //предусловие, здание было построено
    public abstract Building GetConstructed();
    
    //постусловие здание построено
    protected abstract Task Construct(BuildingType type);

    private BuildingConstructionCost? GetConstructionCost(BuildingType buildingType)
    {
        return GetAllConstructionsCosts().FirstOrDefault(c => c.Type == buildingType);
    }

    private BuildingModernizationCost? GetModernizationCost(BuildingType buildingType)
    {
        return GetAllModernizationsCost().FirstOrDefault(c => c.Type == buildingType);
    }
}