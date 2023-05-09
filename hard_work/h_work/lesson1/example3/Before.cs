using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace h_work.lesson1.example3;

public enum RiskLevel
{
    Low,
    High,
    Medium
}

public enum DictionaryType
{
    Industry = 1,
    SourceOfWealth = 2,
}
public class DictionaryItem
{
    public Guid Id { get; init; }
    public DictionaryType Type { get; init; }
    public string Value { get; init; }
}

public class RiskLevelItem
{
    public Guid Id { get; init; }
    public Guid DictionaryItemId { get; set; }
    public RiskLevel Level { get; set; }
}

public record RiskSource
{
    public string Value { get; set; }
    public string IndustryCode { get; set; }
    public RiskLevel Level { get; set; }
}
public static class L1Example3
{
    private static string[] SourcesWithManualRiskSetting = new string[] { "1", "2" };
    private static string[] SourcesWithRiskSettingByIndustry = new string[] { "3", "4" };
    
    public static void Test(RiskSource source, List<DictionaryItem> dictionaryItems, List<RiskLevelItem> riskLevels)
    {
        RiskLevel sourceRiskLevel;
        Guid? sourceRiskFactorLevelId;
        if (source.Value.In(SourcesWithManualRiskSetting))
        {
            sourceRiskLevel = source.Level;
            sourceRiskFactorLevelId = null;
        }
        else if (source.Value.In(SourcesWithRiskSettingByIndustry))
        {
            var industryDictionaryItem = dictionaryItems
                .First(x => x.Type == DictionaryType.Industry && string.Equals(x.Value, source.IndustryCode));
            var sourceRiskFactorLevel = riskLevels.First(x => x.DictionaryItemId == industryDictionaryItem.Id);
            sourceRiskLevel = sourceRiskFactorLevel.Level;
            sourceRiskFactorLevelId = sourceRiskFactorLevel.Id;
        }
        else
        {
            var sourceDictionaryItem = dictionaryItems
                .First(x => x.Type == DictionaryType.SourceOfWealth &&
                            string.Equals(x.Value, source.Value.ToString()));
            var sourceRiskFactorLevel = riskLevels.First(x => x.DictionaryItemId == sourceDictionaryItem.Id);
            sourceRiskLevel = sourceRiskFactorLevel.Level;
            sourceRiskFactorLevelId = sourceRiskFactorLevel.Id;
        }
    }
}

public static class Extensions
{
    public static bool In<T>(this T element, params T[] elements) => Enumerable.Contains<T>((IEnumerable<T>) elements, element);
}
