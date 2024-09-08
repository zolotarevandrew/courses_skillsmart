namespace h_work.lesson69;

public enum AlertType
{
    
}

public enum KvkAlertCode
{
    NoProduct
}
public class KvkAlert
{
    private KvkAlert(AlertType type, KvkAlertCode code, string sourceMessage) 
    {
    }

    public static KvkAlert From(AlertType type, string code, string sourceMessage)
    {
        KvkAlertCode? kvkAlertCode = code switch
        {
            "IPD0001" => KvkAlertCode.NoProduct,
            _ => null
        };

        if (kvkAlertCode is null)
            return null;

        return new KvkAlert(type, kvkAlertCode.Value, sourceMessage);
    }
}