

using KingdomStrategy.Domain.Resources;

namespace KingdomStrategy.Domain.Buildings.Constructors;

public class BuildingConstructorList
{
    private List<BuildingConstructor> _constructors;
    public BuildingConstructorList(List<BuildingConstructor> constructors)
    {
        _constructors = constructors;
    }
}
public abstract class BuildingConstructor : Any
{

    //предусловие, возможно создать такое здание
    //предусловие, нет здания в процессе постройки
    //предусловие, достаточно ресурсов для создания
    //постусловие, нужные ресурсы получены
    //постусловие, постройка здания начата
    public async Task Construct(BuildingConstructionRequest request, ResourceManager resourceManager)
    {
        //todo нет здания в процессе постройки
        
        if (!CanConstruct(request.Cost.Type))
        {
            ConstructResult = 1;
            return;
        }
        
        await resourceManager.ConsumePool(request.Cost.Pool);
        if (resourceManager.ConsumePoolResult != 1)
        {
            ConstructResult = 2;
            return;
        }
        
        ConstructResult = 0;
    }

    //предусловие, возможно модернизировать такое здание
    //предусловие, достаточно ресурсов для модернизации
    //постусловие, нужные ресурсы получены
    //постусловие, здание модернизировано
    public async Task Modernize(BuildingModernizationRequest request, ResourceManager resourceManager)
    {
        if (!CanModernize(request.Building.Type))
        {
            ModernizeResult = 1;
            return;
        }
        
        await resourceManager.ConsumePool(request.Cost.Pool);
        if (resourceManager.ConsumePoolResult != 1)
        {
            ModernizeResult = 2;
            return;
        }
        
        await request.Building.Modernize();
        ModernizeResult = 0;
    }
    
    public abstract Task<BuildingConstructionCostList> GetAllConstructionsCosts();
    public abstract Task<BuildingModernizationCostList> GetAllModernizationsCost();
    
    protected abstract bool CanModernize(BuildingType buildingType);
    protected abstract bool CanConstruct(BuildingType buildingType);
    
    public int ModernizeResult { get; protected set; }
    public int ConstructResult { get; protected set; }
}