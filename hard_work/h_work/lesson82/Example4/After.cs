namespace h_work.lesson82.Example4;

public interface IDateTime
{
    DateTime UtcNow { get; } 
}
public class ReminderScheduleDate
{
    public DateTime UtcValue { get; }
    public TimeSpan Expiration { get; }
    private ReminderScheduleDate(DateTime date, TimeSpan expiration)
    {
        UtcValue = date;
        Expiration = expiration;
    }

    public static ReminderScheduleDate Create(DateTime date, IDateTime dateTime)
    {
        var now = dateTime.UtcNow;
        var maxDate = now.AddDays(6);
        var minDate = now.AddMinutes(5);

        //date.ContractMust( (d) => d >= minDate, "Date is less than allowed MinDate");
        //date.ContractMust( (d) => d <= maxDate, "Date is greater than allowed MaxDate");

        var expiration = date - now;
        return new ReminderScheduleDate(date, expiration);
    }
}
