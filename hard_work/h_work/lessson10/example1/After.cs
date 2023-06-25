namespace h_work.lessson10.example1;

//Response Будет дергаться уже внутри сервиса, и проверять активность из двух источников
public interface ICompanyInactivityService
{
    Task<bool> IsInactive(IBankOnboardingContext context);
}

//сервис будет резолвиться в фабрике для версии contex-а 1.29
public class WithBlockUploadDocumentsService
{
    private readonly ICompanyInactivityService _companyInactivityService;

    public WithBlockUploadDocumentsService(ICompanyInactivityService companyInactivityService)
    {
        _companyInactivityService = companyInactivityService;
    }

    public async Task Execute(IBankOnboardingContext context)
    {
        bool? companyIsInactive = await _companyInactivityService.IsInactive(context);
    }
}