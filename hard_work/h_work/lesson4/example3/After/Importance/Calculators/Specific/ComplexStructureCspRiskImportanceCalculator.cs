using h_work.lesson4.example3.After.RiskFactors;

namespace h_work.lesson4.example3.After.Importance.Calculators.Specific;

public class ComplexStructureCspRiskImportanceCalculator : RiskImportanceCalculator
{
    private readonly RiskFactor _csp;

    public ComplexStructureCspRiskImportanceCalculator(ByTypeRiskFactors byTypeRiskFactors, RiskFactor csp) : base(byTypeRiskFactors)
    {
        _csp = csp;
    }

    public override async Task<RiskImportanceList> Calc()
    {
        return new RiskImportanceList(new ImportantRisk(_csp));
    }
}