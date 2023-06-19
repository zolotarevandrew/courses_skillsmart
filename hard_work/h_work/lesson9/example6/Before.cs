
namespace h_work.lesson9.example6;

public interface IPersonVerificationStepGetter
{
    Task<(IBankOnboardingContext Context, BankOnboardingStepFullInfo Step, bool IsRegistrator)> Get(Guid onboardingId, Guid personId);
}

public class BankOnboardingStepFullInfo
{
}

public interface IBankOnboardingContext
{
}

public class PersonVerificationStepGetter : IPersonVerificationStepGetter
{
    private readonly IBankOnboardingContextService _onboardingContext;
    private readonly IBankOnboardingPersonStepsService _onboardingPersonSteps;
    private readonly IBankOnboardingStepsService _onboardingSteps;
    private readonly IOnboardingRegistratorService _onboardingRegistrator;

    public PersonVerificationStepGetter(
        IBankOnboardingPersonStepsService onboardingPersonSteps,
        IBankOnboardingContextService onboardingContext,
        IOnboardingRegistratorService onboardingRegistrator,
        IBankOnboardingStepsService onboardingSteps)
    {
        _onboardingPersonSteps = onboardingPersonSteps;
        _onboardingContext = onboardingContext;
        _onboardingRegistrator = onboardingRegistrator;
        _onboardingSteps = onboardingSteps;
    }

    public async Task<(IBankOnboardingContext Context, BankOnboardingStepFullInfo Step, bool IsRegistrator)> Get(Guid onboardingId, Guid personId)
    {
        IBankOnboardingContext context = await _onboardingContext.GetById(onboardingId);

        var isRegistrator = await _onboardingRegistrator.IsRegistrator(onboardingId, personId);
        if (isRegistrator)
        {
            var step = await _onboardingPersonSteps.GetStepOrNull(context, EBankOnboardingStep.RegistratorVerification, personId)
                       ?? await _onboardingSteps.GetOneStepOrNull(context, EBankOnboardingStep.RegistratorVerification);
            return (context, step, true);
        }

        var nonRegistratorStep = await _onboardingPersonSteps.GetStepOrNull(context, EBankOnboardingStep.NonRegistratorVerification, personId);
        return (context, nonRegistratorStep, false);
    }
}

public interface IOnboardingRegistratorService
{
    Task<bool> IsRegistrator(Guid onboardingId, Guid personId);
}

public interface IBankOnboardingStepsService
{
    Task<BankOnboardingStepFullInfo?> GetOneStepOrNull(IBankOnboardingContext context, EBankOnboardingStep registratorVerification);
}

public interface IBankOnboardingPersonStepsService
{
    Task<BankOnboardingStepFullInfo?> GetStepOrNull(IBankOnboardingContext context, EBankOnboardingStep registratorVerification, Guid personId);
}

public interface IBankOnboardingContextService
{
    Task<IBankOnboardingContext> GetById(Guid onboardingId);
}

public enum EBankOnboardingStep
{
    RegistratorVerification,
    NonRegistratorVerification,
    Dashboard
}