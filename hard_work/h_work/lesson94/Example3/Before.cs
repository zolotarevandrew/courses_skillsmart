namespace h_work.lesson94.Example3;

public class Before
{
    /*
     public class ManualStepExecutionContract
{
  
    public EBankOnboardingStep[] CandidateSteps { get; set; }
    public UserInfo User { get; set; }
    public IBankOnboardingContext? OnboardingContext { get; set; }
    public object StepData { get; set; }
}
      public async Task<ManualStepExecutionResult> TryExecuteInProgressStep(ManualStepExecutionContract executionContract)
    {
        var candidateSteps = executionContract.CandidateSteps ?? throw new ArgumentException(nameof(executionContract.CandidateSteps));
        var user = executionContract.User ?? throw new ArgumentException(nameof(executionContract.User));
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