using h_work.lesson18.part1.example1;
using h_work.lesson18.part1.example2;
using h_work.lesson18.part3.example1;

namespace h_work.lesson94.Example3;

public class ManualStepExecutionContract(
    EBankOnboardingStep[] candidateSteps,
    UserInfo user,
    object stepData)
{
    public EBankOnboardingStep[] CandidateSteps { get; } = candidateSteps;
    public UserInfo User { get; } = user;
    public object StepData { get; } = stepData;

    public IBankOnboardingContext? OnboardingContext { get; set; }
    
}
public class After
{
    /*
      public async Task<ManualStepExecutionResult> TryExecuteInProgressStep(ManualStepExecutionContract executionContract)
    {
        var candidateSteps = executionContract.CandidateSteps;
        var user = executionContract.User;
        var onboardingContext = executionContract.OnboardingContext ?? await _bankOnboardingService.GetContext(user.Id, user.Company.Id);
        if (onboardingContext is null
            || executionContract.OnboardingContext.IsCompleted()
            || executionContract.OnboardingContext.IsAccountDeclined())
        {
            return ManualStepExecutionResult.NotAvailable(onboardingContext);
        }

        var stepInfo = await GetInProgressStepOrNull(onboardingContext, candidateSteps);
        if (stepInfo is null)
        {
            return ManualStepExecutionResult.NotAvailable(onboardingContext);
        }

        return await Execute(onboardingContext, stepInfo, user, executionContract.StepData);
    }
     */
}