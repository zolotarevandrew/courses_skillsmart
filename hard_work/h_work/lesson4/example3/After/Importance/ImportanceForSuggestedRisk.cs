using h_work.lesson4.example3.After.RiskFactors;

namespace h_work.lesson4.example3.After.Importance;

public class ImportanceForSuggestedRisk : RiskImportance
{
    public ImportanceForSuggestedRisk(RiskFactor riskFactor) : base(riskFactor)
    {
        Value = new RiskImportanceValue(50);
    }

    public override RiskImportanceValue Value { get; }
}