using h_work.lesson4.example3.After.RiskFactors;

namespace h_work.lesson4.example3.After.Importance;

public class NotImportantRisk : RiskImportance
{
    public NotImportantRisk(RiskFactor riskFactor) : base(riskFactor)
    {
        Value = new RiskImportanceValue(0);
    }

    public override RiskImportanceValue Value { get; }
}