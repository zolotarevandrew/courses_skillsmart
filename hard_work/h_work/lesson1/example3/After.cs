namespace h_work.lesson1.example3;


public class RiskLevelRef
{
    public RiskLevel Level { get; init; }
    public Guid Id { get; init; }

    public RiskLevelRef(RiskLevel level, Guid id)
    {
        Level = level;
        Id = id;
    }
}


public class RiskLevelRefCalculator
{
    private List<DictionaryItem> _dictionaryItems;
    private List<RiskLevelItem> _riskLevels;

    public RiskLevelRefCalculator(
        List<DictionaryItem> dictionaryItems, 
        List<RiskLevelItem> riskLevels)
    {
        _dictionaryItems = dictionaryItems;
        _riskLevels = riskLevels;
    }
    
    public RiskLevelRef Calc(RiskSource sourceValue)
    {
        Dictionary<string, Func<RiskSource, RiskLevelRef>> riskSourceCreators = new Dictionary<string, Func<RiskSource, RiskLevelRef>>
        {
            {"1", CalcManual},
            {"2", CalcManual},
            {"3", CalcIndustry},
            {"4", CalcIndustry},
            {"5", CalcWealth}
        };
        
        if (riskSourceCreators.TryGetValue(sourceValue.Value, out var creator))
        {
            return creator(sourceValue);
        }

        throw new ArgumentException($"Unknown source value: {sourceValue}");
    }

    RiskLevelRef CalcManual(RiskSource source)
    {
        return new RiskLevelRef(source.Level, Guid.NewGuid());
    }
    
    public RiskLevelRef CalcWealth(RiskSource source)
    {
        var sourceDictionaryItem = _dictionaryItems
            .First(x => x.Type == DictionaryType.SourceOfWealth &&
                        string.Equals(x.Value, source.Value.ToString()));
        var sourceRiskFactorLevel = _riskLevels.First(x => x.DictionaryItemId == sourceDictionaryItem.Id);
        
        return new RiskLevelRef(sourceRiskFactorLevel.Level, sourceDictionaryItem.Id);
    }
    
    public RiskLevelRef CalcIndustry(RiskSource source)
    {
        var industryDictionaryItem = _dictionaryItems
            .First(x => x.Type == DictionaryType.Industry && string.Equals(x.Value, source.IndustryCode));
        var sourceRiskFactorLevel = _riskLevels.First(x => x.DictionaryItemId == industryDictionaryItem.Id);
        
        return new RiskLevelRef(sourceRiskFactorLevel.Level, industryDictionaryItem.Id);
    }
}
