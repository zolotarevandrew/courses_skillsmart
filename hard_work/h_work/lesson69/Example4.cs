namespace h_work.lesson69;

public interface ITypedAlert
{
    string Description { get; }
    Task<AlertTriggerReason> GetTrigger(TypedAlertContext context);
}

public class TypedAlertContext
{
    public CheckPerson Person { get; init; }
}

public class CheckPerson
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string CountryOfResidence { get; set; }
}

public class Voip935PhoneAlert : ITypedAlert
{
    public string Description => "Voice Over Internet Protocol numbers are Internet-based  numbers. Non-fixed VOIP numbers can easily be obtained by users who are not located in the country associated with the telephone number. They are untraceable and disposable; some can even be obtained for free. This means that a fraudster in Romania could easily obtain a US-based telephone number using a non-fixed VOIP service and receive a call to this number in his or her home in Romania.";

    public async Task<AlertTriggerReason> GetTrigger(TypedAlertContext context)
    {
        await Task.CompletedTask;
        return new AlertTriggerReason
        {
            Trigger = false,
            RiskLevel = ERiskLevel.High
        };
    }
}

public class AlertTriggerReason
{
    public bool Trigger { get; init; }
    public string Value { get; init; } = string.Empty;
    public ERiskLevel? RiskLevel { get; init; }
}

public enum ERiskLevel
{
    Low,
    High
}