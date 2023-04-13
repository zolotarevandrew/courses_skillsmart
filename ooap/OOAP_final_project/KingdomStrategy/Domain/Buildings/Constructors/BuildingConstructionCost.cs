using KingdomStrategy.Domain.Resources;

namespace KingdomStrategy.Domain.Buildings.Constructors;


public class BuildingConstructionCost : Any
{
    public BuildingType Type { get; init; }
    public RequestedResourcePool Pool { get; init; }

    public BuildingConstructionCost(BuildingType type, RequestedResourcePool pool)
    {
        Type = type;
        Pool = pool;
    }
}

public class BuildingConstructionRequest : Any
{
    public BuildingConstructionRequest(BuildingModernizationCost cost)
    {
        Cost = cost;
    }
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