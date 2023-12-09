namespace h_work.lesson29.example1;

public class DictionaryItemContract
{
    public EDictionaryItemState State { get; init; }
    public Dictionary<string, object> Metadata { get; init; }
}

public enum EDictionaryEntity
{
    OrganizationType = 1,
}

public interface IDictionariesService
{
    Task<IEnumerable<DictionaryItemContract>> Get(EDictionaryEntity organizationType, string countryCode, string userLang);
}

public enum EDictionaryItemState
{
    Enabled
}

public class Before
{
    private readonly IDictionariesService _dictionaries;

    public Before(IDictionariesService dictionaries)
    {
        _dictionaries = dictionaries;
    }
    
    public async Task GetLegalForms()
    {
        string countryCode = "DE";
        string userLang = "EN";
        IEnumerable<DictionaryItemContract> legalFormDict =
            (await _dictionaries.Get(EDictionaryEntity.OrganizationType,
                countryCode, userLang)).Where(x => x.State == EDictionaryItemState.Enabled)
            .Where(x => !NeedHide(x.Metadata));
    }
     
    bool NeedHide(Dictionary<string, object> dict)
    {
        if (!dict.ContainsKey("Hide")) return false;
        return (bool)dict["Hide"];
    }
}