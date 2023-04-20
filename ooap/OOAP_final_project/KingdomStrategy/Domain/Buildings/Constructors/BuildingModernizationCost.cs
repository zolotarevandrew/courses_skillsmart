using KingdomStrategy.Domain.Resources;

namespace KingdomStrategy.Domain.Buildings.Constructors;


public class BuildingModernizationCost : Any
{
    public BuildingType Type { get; init; }
    public ResourcePool Resources { get; init; }

    public BuildingModernizationCost(
        BuildingType type,
        ResourcePool resources 
        )
    {
        Resources = resources;
        Type = type;
    }
}

public class BuildingModernizationRequest : Any
{
    public BuildingModernizationRequest(
        Building building, 
        ResourceManager resourceManager)
    {
        Building = building;
        ResourceManager = resourceManager;
    }

    public Building Building { get; init; }
    public ResourceManager ResourceManager { get; init; }
}