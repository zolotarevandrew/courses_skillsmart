namespace h_work.lessson10.example3;

public class WaitingListProcessorV2
{
    private IDossierOuterService _dossierOuterService;
    public WaitingListProcessorV2(IDossierOuterService dossierOuterService)
    {
        _dossierOuterService = dossierOuterService;
    }
    public async Task Run(Guid companyId)
    {
        var flags = await _dossierOuterService.GetCompanyFlags(companyId);
        if (flags.ComplicatedByCountry)
        {

        }
    }
}