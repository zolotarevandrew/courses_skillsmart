namespace KingdomStrategy.Domain.Buildings;

public class BuildingInfo
{
    public BuildingInfo(BuildingCapacity capacity, bool isModernized)
    {
        Capacity = capacity;
        IsModernized = isModernized;
    }

    public BuildingCapacity Capacity { get; init; }
    public bool IsModernized { get; init; }
}