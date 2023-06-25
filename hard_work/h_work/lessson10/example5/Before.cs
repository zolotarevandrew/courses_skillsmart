namespace h_work.lessson10.example5;


public interface IScreeningService
{
    Task<ScreenResult> Screen(string regName);
}

public class ScreenResult
{
    public bool HasSanctionsType(SanctionList list)
    {
        throw new NotImplementedException();
    }
}

public class SanctionList
{

}

public class Company
{
    public string RegisteredName { get; set; }
}

public class CompanyScreeningTaskHandler
{
    private readonly IScreeningService _screeningService;
    public CompanyScreeningTaskHandler(IScreeningService screeningService)
    {
        _screeningService = screeningService;
    }

    public async Task ScreenAll()
    {
        bool autoCheckTicket = false;
        var list = new SanctionList();
        var company = new Company();


        var screenedRegName = autoCheckTicket ? await _screeningService.Screen(company.RegisteredName) : null;
        if (!autoCheckTicket || screenedRegName.HasSanctionsType(list))
        {

        }
    }

}