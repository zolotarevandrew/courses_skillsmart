namespace h_work.lesson4.example2.After.Parameters;

public abstract class ScreeningParameter
{
    public Guid CompanyId { get; }
    public Guid EntityId { get; set; }
    public Guid? Id { get; set; }

    public abstract string ScreeningValue { get; }
    public abstract EEntityType EntityType { get; }
    public abstract EParameterType Type { get; }

    protected ScreeningParameter(Guid companyId, Guid entityId, Guid? parameterId = null)
    {
        CompanyId = companyId;
        EntityId = entityId;
        Id = parameterId;
    }

    public ScreeningParameterSharedKey SharedKey => new(EntityId, ScreeningValue, Type);
}

public class ScreeningParameterSharedKey
{
    public string Value { get; }
    public ScreeningParameterSharedKey(Guid entityId, string value, EParameterType parameterType)
    {
        Value = $"{entityId}_{value}_{parameterType}"; 
    }
}