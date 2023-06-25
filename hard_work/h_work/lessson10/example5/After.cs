namespace h_work.lessson10.example5;

public class AutoCheckCompanyScreeningTaskHandler
{
    private readonly IScreeningService _screeningService;
    public AutoCheckCompanyScreeningTaskHandler(IScreeningService screeningService)
    {
        _screeningService = screeningService;
    }

    public async Task ScreenAll()
    {
        var list = new SanctionList();
        var company = new Company();

        var screenedRegName = await _screeningService.Screen(company.RegisteredName);
        if (screenedRegName.HasSanctionsType(list))
        {

        }
    }

}