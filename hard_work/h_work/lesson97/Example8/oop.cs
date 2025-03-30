

public abstract class VehiclePts
{
    
}

public class OldVehiclePts : VehiclePts {}
public class ElectronicVehiclePts : VehiclePts {}


public readonly struct VehiclePtsIssueYear(int year)
{
    public int Year { get; } = year;
};

public static class VehiclePtsFactory
{
    public static VehiclePts GetByIssueYear(VehiclePtsIssueYear ptsIssueYear) =>
        ptsIssueYear.Year <= 2021
            ? new OldVehiclePts()
            : new ElectronicVehiclePts();
}