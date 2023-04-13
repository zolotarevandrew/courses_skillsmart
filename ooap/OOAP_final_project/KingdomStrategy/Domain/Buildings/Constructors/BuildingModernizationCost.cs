using KingdomStrategy.Domain.Resources;

namespace KingdomStrategy.Domain.Buildings.Constructors;


public class BuildingModernizationCost : Any
{
    public BuildingType Type { get; init; }
    public RequestedResourcePool Pool { get; init; }

    public BuildingModernizationCost(
        RequestedResourcePool pool, 
        BuildingType type)
    {
        Pool = pool;
        Type = type;
    }
}

public class BuildingModernizationRequest : Any
{
    public BuildingModernizationRequest(
        Building building, 
        BuildingModernizationCost cost)
    {
        Building = building;
        Cost = cost;
    }

    public Building Building { get; init; }
    public BuildingModernizationCost Cost { get; init; }
}

public class BuildingModernizationCostList
{
    private List<BuildingModernizationCost> _costs;

    public BuildingModernizationCostList(List<BuildingModernizationCost> costs)
    {
        _costs = costs;
    }
}