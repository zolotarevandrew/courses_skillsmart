namespace h_work.lesson4.example3;

public class EntityRiskImportanceChecker
{
    public async Task<List<RiskImportanceContract>> GetValuableRiskFactors(List<EntityRiskImportanceCalculationData> riskFactorsForSpecificProcessing)
    {
        var checkResult = new Dictionary<Guid, RiskImportanceContract>();
        var groupedRiskFactors = riskFactorsForSpecificProcessing
            .GroupBy(x => new
            {
                x.RiskFactor,
                x.ParameterType,
                x.EntityId,
            })
            .ToDictionary(x => x.Key, x => x.ToList());

        foreach (var (key, groupRiskFactors) in groupedRiskFactors)
        {
            List<Guid> valuableEntityRisks = (key.RiskFactor, key.ParameterType) switch
            {
                (ERiskFactor.IndustryCheck, EParameter.CompanyIndustry) =>
                    await FindForCompanyMainIndustry(groupRiskFactors),
                _ => new List<Guid>()
            };

            foreach (var entityRiskFactor in groupRiskFactors)
            {
                checkResult[entityRiskFactor.Id] = valuableEntityRisks.Contains(entityRiskFactor.Id)
                    ? RiskImportanceContract.ImportantForAll(entityRiskFactor.Id)
                    : RiskImportanceContract.NotImportant(entityRiskFactor.Id);
            }
        }

        GetValuableRiskBetweenLRandSCP(riskFactorsForSpecificProcessing, checkResult);

        return checkResult.Select(x => x.Value).ToList();
    }

    private async Task<List<Guid>> FindForCompanyMainIndustry(List<EntityRiskImportanceCalculationData> groupRiskFactors)
    {
        return groupRiskFactors
            .Where(c => c.ParameterType == EParameter.CompanyIndustry)
            .Select(c => c.Id)
            .ToList();
    }

    public static void GetValuableRiskBetweenLRandSCP(
        List<EntityRiskImportanceCalculationData> riskFactorsForSpecificProcessing, 
        Dictionary<Guid, RiskImportanceContract> checkResult)
    {
        var complexStructureRisk = riskFactorsForSpecificProcessing.FirstOrDefault(x =>
            x.RiskFactor is ERiskFactor.ComplexStructureSCP);

        var businessIsLegalRepresentativeRisk = riskFactorsForSpecificProcessing.FirstOrDefault(x =>
            x.RiskFactor is ERiskFactor.BusinessIsLegalRepresentative &&
            x.ParameterType is EParameter.LegalEntityName);

        var complexStructureRiskImportant = new RiskImportanceContract(complexStructureRisk?.Id ?? Guid.Empty);
        var businessIsLegalRepresentativeRiskImportant =
            new RiskImportanceContract(businessIsLegalRepresentativeRisk?.Id ?? Guid.Empty);

        // auto risk importance
        var complexStructureAutoRiskScore = complexStructureRisk?.FinalScore ?? 0;
        var businessIsLegalRepresentativeAutoRiskScore = businessIsLegalRepresentativeRisk?.FinalScore ?? 0;

        if (complexStructureAutoRiskScore > businessIsLegalRepresentativeAutoRiskScore && complexStructureRisk is not null)
        {
            complexStructureRiskImportant.ImportanceWithoutSuggested = true;
        }
        else if (businessIsLegalRepresentativeRisk is not null)
        {
            businessIsLegalRepresentativeRiskImportant.ImportanceWithoutSuggested = true;
        }
            
        // final and suggested risk importance
        var complexStructureRiskScore = EntityRiskFactorHelper.GetRiskValueScore(complexStructureRisk);

        var businessIsLegalRepresentativeRiskScore = EntityRiskFactorHelper.GetRiskValueScore(businessIsLegalRepresentativeRisk);

        if (complexStructureRiskScore > businessIsLegalRepresentativeRiskScore && complexStructureRisk is not null)
        {
            complexStructureRiskImportant.ImportanceWithSuggested = true;
        }
        else if (businessIsLegalRepresentativeRisk is not null)
        {
            businessIsLegalRepresentativeRiskImportant.ImportanceWithSuggested = true;
        }

        if (complexStructureRisk is not null)
        {
            checkResult[complexStructureRisk.Id] = complexStructureRiskImportant;
        }

        if (businessIsLegalRepresentativeRisk is not null)
        {
            checkResult[businessIsLegalRepresentativeRisk.Id] = businessIsLegalRepresentativeRiskImportant;
        }
    }
}

public class EntityRiskFactorHelper
{
    public static decimal GetRiskValueScore(EntityRiskImportanceCalculationData complexStructureRisk)
    {
        //something to calculate;
        return 0;
    }
}

public enum ERiskFactor
{
    ComplexStructureSCP,
    BusinessIsLegalRepresentative,
    IndustryCheck
}

public enum EParameter
{
    LegalEntityName,
    CompanyIndustry
}

public class RiskImportanceContract
{

    public RiskImportanceContract(Guid id)
    {
        RiskFactorId = id;
    }
    
    public Guid RiskFactorId { get; set; }

    public bool ImportanceWithoutSuggested { get; set; }
    public bool ImportanceWithSuggested { get; set; }

    public static RiskImportanceContract NotImportant(Guid riskFactorId, string comment = null,
        bool needUpdateComment = false)
    {
        return new RiskImportanceContract(riskFactorId)
        {
            ImportanceWithoutSuggested = false, 
            ImportanceWithSuggested = false, 
            Comment = comment,
            CommentNeedUpdate = !string.IsNullOrWhiteSpace(comment) || needUpdateComment
        };
    }
    
    public static RiskImportanceContract ImportantForAll(Guid riskFactorId, bool needUpdateComment = false)
    {
        return new RiskImportanceContract(riskFactorId)
        {
            ImportanceWithoutSuggested = true, 
            ImportanceWithSuggested = true, 
            Comment = null, 
            CommentNeedUpdate = needUpdateComment
        };
    }

    public string Comment { get; set; }

    public bool CommentNeedUpdate { get; set; }
}

public class EntityRiskImportanceCalculationData
{
    public Guid Id { get; set; }
    public decimal FinalScore { get; set; }
    public ERiskFactor RiskFactor { get; set; }
    public EParameter ParameterType { get; set; }
    public Guid EntityId { get; set; }
}