namespace h_work.lessson10.example2;

public interface IOnboardingService
{
    Task<IBankOnboardingContext> Get(Guid onboardingId);
}

public interface IBankOnboardingContext
{
    public OnboardingType Type { get; }
    public BankCode Bank { get; }
}

public enum OnboardingType
{
    Freelance,
    FreelanceUnderRegistration
}

public enum BankCode
{
    Bank1,
}

public class OnboardingStepChangedMessage
{
    public Guid OnboardingId { get; set; }
}
public class StepChangedHandler
{
    private readonly IOnboardingService _onboardingService;

    public StepChangedHandler(IOnboardingService _onboardingService)
    {
        _onboardingService = _onboardingService;
    }


    public async Task Run(OnboardingStepChangedMessage step) {
        IBankOnboardingContext context = await _onboardingService.Get(step.OnboardingId);
        if (context.Type != OnboardingType.Freelance && context.Type != OnboardingType.FreelanceUnderRegistration
            && context.Bank == BankCode.Bank1)
        {
            // do something
        }
    }
}