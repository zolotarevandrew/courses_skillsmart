using KingdomStrategy.Domain.Resources;

namespace KingdomStrategy.Domain.Buildings.Constructors;

public class BuildingConstructionCost : Any
{
    public BuildingType Type { get; init; }
    public ResourcePool Resources { get; init; }

    public BuildingConstructionCost(BuildingType type, ResourcePool resources)
    {
        Type = type;
        Resources = resources;
    }
}

public class BuildingConstructionRequest : Any
{
    public BuildingType Type { get; }
    public ResourceManager ResourceManager { get; }

    public BuildingConstructionRequest(BuildingType type, ResourceManager resourceManager)
    {
        Type = type;
        ResourceManager = resourceManager;
    }
    
}