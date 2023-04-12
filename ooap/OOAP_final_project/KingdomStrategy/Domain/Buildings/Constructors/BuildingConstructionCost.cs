using KingdomStrategy.Domain.Resources;

namespace KingdomStrategy.Domain.Buildings.Constructors;


public class BuildingConstructionCost : Any
{
    public RequestedResourcePool Pool { get; init; }

    public BuildingConstructionCost(RequestedResourcePool pool)
    {
        Pool = pool;
    }
}

public class BuildingConstructionRequest : Any
{
    public BuildingConstructionRequest(
        BuildingType type, 
        BuildingModernizationCost cost)
    {
        Type = type;
        Cost = cost;
    }

    public BuildingType Type { get; init; }
    public BuildingModernizationCost Cost { get; init; }
}

public class BuildingConstructionCostList : Any
{
    private List<BuildingConstructionCost> _costs;

    public BuildingConstructionCostList(List<BuildingConstructionCost> costs)
    {
        _costs = costs;
    }
}