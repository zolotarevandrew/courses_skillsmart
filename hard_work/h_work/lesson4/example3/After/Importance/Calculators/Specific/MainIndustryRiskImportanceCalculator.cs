using h_work.lesson4.example3.After.RiskFactors;

namespace h_work.lesson4.example3.After.Importance.Calculators.Specific;

public class MainIndustryRiskImportanceCalculator : RiskImportanceCalculator
{
    public MainIndustryRiskImportanceCalculator(ByTypeRiskFactors byTypeRiskFactors) : base(byTypeRiskFactors)
    {
    }

    public override async Task<RiskImportanceList> Calc()
    {
        return new RiskImportanceList(ByTypeRiskFactors
            .Value
            .Select(c => new ImportantRisk(c) as RiskImportance)
            .ToList());
    }
}