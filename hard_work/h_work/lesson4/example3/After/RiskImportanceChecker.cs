using h_work.lesson4.example3.After.Importance.Calculators;
using h_work.lesson4.example3.After.RiskFactors;

namespace h_work.lesson4.example3.After;

public class RiskImportanceChecker
{
    private readonly IRiskImportanceCalculatorFactory _importanceCalculatorFactory;
    public RiskImportanceChecker(IRiskImportanceCalculatorFactory importanceCalculatorFactory)
    {
        _importanceCalculatorFactory = importanceCalculatorFactory;
    }
    public async Task Check(List<RiskFactor> factors)
    {
        var groupedRiskFactors = factors
            .GroupBy(x => new
            {
                x.Type,
                x.ParameterType,
                x.EntityId,
            })
            .ToDictionary(x => x.Key, x => x.ToList());

        foreach (var (key, groupRiskFactors) in groupedRiskFactors)
        {
            var byTypeRiskFactor = new ByTypeRiskFactors(key.Type, key.ParameterType, key.EntityId, groupRiskFactors);
            var calculator = _importanceCalculatorFactory.Get(byTypeRiskFactor);

            var importance = await calculator.Calc();
            //TODO something
        }
        
    }
}