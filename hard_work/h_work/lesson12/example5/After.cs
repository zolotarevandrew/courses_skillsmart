namespace h_work.lesson12.example5;

public class Alert
{
    public AlertType Type { get; }
    public AlertCode Code { get; }
    public string SourceMessage { get; }

    public Alert(AlertType type, AlertCode code, string sourceMessage)
    {
        Type = type;
        Code = code;
        SourceMessage = sourceMessage;
    }
    
    public static Alert From(AlertType type, string code, string sourceMessage)
    {
        switch (code)
        {
            case "NOT_FOUND":
                return new Alert(type, AlertCode.CompanyNotFound, sourceMessage);
            default:
                return new Alert(type, AlertCode.Unknown, sourceMessage);
        }
    }
}

public enum AlertType
{
}

public enum AlertCode
{
    CompanyNotFound,
    Unknown
}