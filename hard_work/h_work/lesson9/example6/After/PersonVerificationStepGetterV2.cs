namespace h_work.lesson9.example6.After;

public interface IPersonVerificationStepGetterV2
{
    Task<BankOnboardingStepFullInfo?> Get(IBankOnboardingContext context, Guid personId);
}

public class PersonVerificationStepGetterV2 : IPersonVerificationStepGetterV2
{
    private readonly IBankOnboardingPersonStepsService _onboardingPersonSteps;
    

    public PersonVerificationStepGetterV2(IBankOnboardingPersonStepsService onboardingPersonSteps)
    {
        _onboardingPersonSteps = onboardingPersonSteps;
    }

    public async Task<BankOnboardingStepFullInfo?> Get(IBankOnboardingContext context, Guid personId)
    {
        return await _onboardingPersonSteps.GetStepOrNull(context, EBankOnboardingStep.RegistratorVerification, personId)
                   ?? await _onboardingPersonSteps.GetStepOrNull(context, EBankOnboardingStep.NonRegistratorVerification, personId);
    }
}