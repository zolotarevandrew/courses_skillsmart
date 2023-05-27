namespace h_work.lesson4.example3.After.RiskFactors;

public class ByTypeRiskFactors
{
    public IEnumerable<RiskFactor> Value { get; }
    public ERiskFactor Factor { get; }
    public EParameter Parameter { get; }
    public Guid EntityId { get; }

    public ByTypeRiskFactors(
        ERiskFactor factor, 
        EParameter parameter, 
        Guid entityId, 
        IEnumerable<RiskFactor> factors)
    {
        Factor = factor;
        Parameter = parameter;
        EntityId = entityId;
        Value = factors;
    }
}