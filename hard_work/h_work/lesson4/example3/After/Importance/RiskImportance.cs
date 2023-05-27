using h_work.lesson4.example3.After.RiskFactors;

namespace h_work.lesson4.example3.After.Importance;

public class RiskImportanceValue
{
    private readonly int _value;
    public RiskImportanceValue(int value)
    {
        _value = value;
    }
}

public abstract class RiskImportance
{
    public RiskFactor RiskFactor { get; }
    public abstract RiskImportanceValue Value { get; }

    protected RiskImportance(RiskFactor riskFactor)
    {
        RiskFactor = riskFactor;
    }
}

public class RiskImportanceList
{
    private readonly List<RiskImportance> _importance;

    public RiskImportanceList(List<RiskImportance> importance)
    {
        _importance = importance;
    }
    
    public RiskImportanceList(RiskImportance importance)
    {
        _importance = new List<RiskImportance>
        {
            importance
        };
    }
}
