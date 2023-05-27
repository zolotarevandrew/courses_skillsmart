using h_work.lesson4.example3.After.Importance.Calculators.Specific;
using h_work.lesson4.example3.After.RiskFactors;

namespace h_work.lesson4.example3.After.Importance.Calculators;

public abstract class RiskImportanceCalculator
{
    protected readonly ByTypeRiskFactors ByTypeRiskFactors;

    protected RiskImportanceCalculator(ByTypeRiskFactors byTypeRiskFactors)
    {
        ByTypeRiskFactors = byTypeRiskFactors;
    }

    public abstract Task<RiskImportanceList> Calc();
}

public interface IRiskImportanceCalculatorFactory
{
    RiskImportanceCalculator Get(ByTypeRiskFactors byTypeRiskFactors);
}

public class RiskImportanceCalculatorFactory : IRiskImportanceCalculatorFactory
{
    public RiskImportanceCalculator Get(ByTypeRiskFactors byTypeRiskFactors)
    {
        return (byTypeRiskFactors.Factor, byTypeRiskFactors.Parameter) switch
        {
            (ERiskFactor.IndustryCheck, EParameter.CompanyIndustry) when byTypeRiskFactors.Value.Any() => new MainIndustryRiskImportanceCalculator(byTypeRiskFactors),
            (ERiskFactor.ComplexStructureSCP, _) when byTypeRiskFactors.Value.Any() => GetComplexCspCalculator(byTypeRiskFactors),
            
            _ => throw new ArgumentOutOfRangeException()
        };
    }

    private RiskImportanceCalculator GetComplexCspCalculator(ByTypeRiskFactors byTypeRiskFactors)
    {
        var complexStructureRisk = byTypeRiskFactors.Value
            .SingleOrDefault(x => x.Type is ERiskFactor.ComplexStructureSCP);

        var businessIsLegalRepresentativeRisk = byTypeRiskFactors.Value
            .FirstOrDefault(x => x.Type is ERiskFactor.BusinessIsLegalRepresentative && x.ParameterType is EParameter.LegalEntityName);

        if (businessIsLegalRepresentativeRisk == null) return new ComplexStructureCspRiskImportanceCalculator(byTypeRiskFactors, complexStructureRisk);

        return new ComplexStructureCspWithLegalRepRiskImportanceCalculator(byTypeRiskFactors, complexStructureRisk, businessIsLegalRepresentativeRisk);
    }
}
