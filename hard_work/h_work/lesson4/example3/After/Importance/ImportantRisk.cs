using h_work.lesson4.example3.After.RiskFactors;

namespace h_work.lesson4.example3.After.Importance;

public class ImportantRisk : RiskImportance
{
    public ImportantRisk(RiskFactor riskFactor) : base(riskFactor)
    {
        Value = new RiskImportanceValue(100);
    }

    public override RiskImportanceValue Value { get; }
}