namespace h_work.lessson10.example2;

public class Bank1FreelanceStepChangedHandler
{
    private readonly IOnboardingService _onboardingService;

    public Bank1FreelanceStepChangedHandler(IOnboardingService _onboardingService)
    {
        _onboardingService = _onboardingService;
    }


    public async Task Run(OnboardingStepChangedMessage step) {
        IBankOnboardingContext context = await _onboardingService.Get(step.OnboardingId);
        // do something
    }
}

public class Bank1FreelanceUnderRegistrationStepChangedHandler
{
    private readonly IOnboardingService _onboardingService;

    public Bank1FreelanceUnderRegistrationStepChangedHandler(IOnboardingService _onboardingService)
    {
        _onboardingService = _onboardingService;
    }


    public async Task Run(OnboardingStepChangedMessage step) {
        IBankOnboardingContext context = await _onboardingService.Get(step.OnboardingId);
        // do something
    }
}