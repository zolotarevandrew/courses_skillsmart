namespace h_work.lesson29.example1;

public class CompanyLegalForm 
{

}

public interface IDictionariesServiceNew
{
    Task<IEnumerable<CompanyLegalForm>> GetLegalForms(string countryCode, string userLang);
}

public class DictionariesServiceNew : IDictionariesServiceNew
{
    private readonly IDictionariesService _dictionariesService;

    public DictionariesServiceNew(IDictionariesService dictionariesService)
    {
        _dictionariesService = dictionariesService;
    }
    public async Task<IEnumerable<CompanyLegalForm>> GetLegalForms(string countryCode, string userLang)
    {
        IEnumerable<DictionaryItemContract> legalFormDict =
            (await _dictionariesService.Get(EDictionaryEntity.OrganizationType,
                countryCode, userLang)).Where(x => x.State == EDictionaryItemState.Enabled)
            .Where(x => !NeedHide(x.Metadata));

        return legalFormDict
            .Select(Map);
    }

    CompanyLegalForm Map(DictionaryItemContract dictionaryItemContract)
    {
        //TODO
        return new CompanyLegalForm();
    }
    
    bool NeedHide(Dictionary<string, object> dict)
    {
        if (!dict.ContainsKey("Hide")) return false;
        return (bool)dict["Hide"];
    }
}