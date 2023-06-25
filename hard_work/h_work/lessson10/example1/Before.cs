namespace h_work.lessson10.example1;

public interface IIneeeService
{
    bool? CompanyIsInactive(Response response);
}

public class Response
{
    public AvisAdditionalData AdditionalData { get; set; }
}

public interface IBankOnboardingContext
{
    public Version Version { get; }
}

public class AvisAdditionalData
{
    public bool IsInactive { get; set; }
}
public class Before
{
    private readonly IIneeeService _ineeeService;
    public Before(IIneeeService ineeeService)
    {
        _ineeeService = ineeeService;
    }
    public void Execute(IBankOnboardingContext context)
    {
        var response = new Response();
        AvisAdditionalData additionalData = response.AdditionalData;
        
        bool? companyIsInactive = _ineeeService.CompanyIsInactive(response);
        if (context.Version >= new Version("1.29")
            && (companyIsInactive == true || additionalData?.IsInactive == true))
        {
           
        }
        
    }
} 