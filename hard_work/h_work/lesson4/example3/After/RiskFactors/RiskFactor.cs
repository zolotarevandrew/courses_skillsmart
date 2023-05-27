namespace h_work.lesson4.example3.After.RiskFactors;

public class RiskFactor
{
    public Guid Id { get; init; }
    public decimal AutoScore { get; init; }
    public ERiskFactor Type { get; init; }
    public EParameter ParameterType { get; init; }
    public Guid EntityId { get; init; }

    public decimal CalcScore()
    {
        throw new NotImplementedException();
    }
}