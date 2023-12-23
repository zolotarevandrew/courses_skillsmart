using h_work.lesson29.example1;

namespace h_work.lesson31.example4;

public class LegalFormValidator
{
    private readonly IDictionariesService _dictionariesService;

    public LegalFormValidator(IDictionariesService dictionariesService)
    {
        _dictionariesService = dictionariesService;
    }

    public async Task Validate(Guid? legalForm, string countryCode)
    {
        /*legalForm.ContractNotNull("legalForm");
        countryCode.ContractNotNull("CountryCode");
        exists.ContractEqual(true, "legalForm not exist");*/
    }

}