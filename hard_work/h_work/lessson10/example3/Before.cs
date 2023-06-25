namespace h_work.lessson10.example3;

public interface IDossierOuterService
{
    Task<CompanyDossierFlags> GetCompanyFlags(Guid companyId);
}

public class CompanyDossierFlags
{
    public bool UnprocessedLegalForm { get; set; }
    public bool ForeignCompanyRepresentative { get; set; }
    public bool ComplicatedByCountry { get; set; }
}

public class WaitingListProcessor
{
    private IDossierOuterService _dossierOuterService;
    public WaitingListProcessor(IDossierOuterService dossierOuterService)
    {
        _dossierOuterService = dossierOuterService;
    }
    public async Task Run(Guid companyId)
    {
        var flags = await _dossierOuterService.GetCompanyFlags(companyId);
        if (flags.UnprocessedLegalForm || flags.ForeignCompanyRepresentative || flags.ComplicatedByCountry)
        {

        }
    }
}