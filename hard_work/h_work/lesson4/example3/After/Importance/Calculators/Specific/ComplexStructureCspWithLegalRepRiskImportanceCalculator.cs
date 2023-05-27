using System.Data;
using h_work.lesson4.example3.After.RiskFactors;

namespace h_work.lesson4.example3.After.Importance.Calculators.Specific;

public class ComplexStructureCspWithLegalRepRiskImportanceCalculator : RiskImportanceCalculator
{
    private readonly RiskFactor _cspRisk;
    private readonly RiskFactor _legalRepRisk;

    public ComplexStructureCspWithLegalRepRiskImportanceCalculator(
        ByTypeRiskFactors byTypeRiskFactors, 
        RiskFactor cspRisk, 
        RiskFactor legalRepRisk) : base(byTypeRiskFactors)
    {
        _cspRisk = cspRisk;
        _legalRepRisk = legalRepRisk;
    }

    public override async Task<RiskImportanceList> Calc()
    {
        var cspAutoRiskScore = _cspRisk.AutoScore;
        var legalRepAutoRiskScore = _legalRepRisk.AutoScore;
        
        var complexStructureRiskScore = _cspRisk.CalcScore();
        var legalRepRiskScore = _legalRepRisk.CalcScore();

        var list = new List<RiskImportance>();
        
        var cspByAutoImportance = cspAutoRiskScore > legalRepAutoRiskScore;
        var cspSuggestedImportance = complexStructureRiskScore > legalRepRiskScore;
        
        if (cspByAutoImportance && cspSuggestedImportance)
        {
            list.Add(new ImportantRisk(_cspRisk));
        }
        if (cspByAutoImportance && !cspSuggestedImportance)
        {
            list.Add(new ImportanceForSuggestedRisk(_cspRisk));
        }
        if (!cspByAutoImportance && !cspSuggestedImportance)
        {
            list.Add(new NotImportantRisk(_cspRisk));
        }

        var legalRepAutoImportance = !cspByAutoImportance;
        var legalRepSuggestedImportance = !cspSuggestedImportance;
        if (legalRepAutoImportance && legalRepSuggestedImportance)
        {
            list.Add(new ImportantRisk(_legalRepRisk));
        }
        if (legalRepAutoImportance && !legalRepSuggestedImportance)
        {
            list.Add(new ImportanceForSuggestedRisk(_legalRepRisk));
        }
        if (!legalRepAutoImportance && !legalRepSuggestedImportance)
        {
            list.Add(new NotImportantRisk(_legalRepRisk));
        }

        return new RiskImportanceList(list);
    }
}