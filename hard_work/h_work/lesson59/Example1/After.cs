
public class Vehicle
{
    public string Category { get; set; }
    public DateTime IssueYear { get; set; }
}
public static class PassFunctions
{
    public static bool IsCCategoryYear2022(Vehicle vehicle)
    {
        return vehicle.Category == "C" && vehicle.IssueYear.Year == 2022;
    }

    public static bool CheckAllowedVehicleFor2022(Vehicle vehicle, DateTime passDate)
    {
        var monthDiff = GetMonthDifference(passDate, vehicle.IssueYear);
        return IsCCategoryYear2022(vehicle) && monthDiff < 12;
    }
    
    
    static int GetMonthDifference(DateTime startDate, DateTime endDate)
    {
        int monthsApart = 12 * (startDate.Year - endDate.Year) + startDate.Month - endDate.Month;
        return Math.Abs(monthsApart);
    }
}

