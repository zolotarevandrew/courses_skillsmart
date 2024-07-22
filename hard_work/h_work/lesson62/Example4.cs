namespace h_work.lesson62;

public class Example4
{
    /*
    private async Task<List<BankOnboardingStepContract>> Before(
        IBankOnboardingContext context, BankOnboardingStepInfo currentStep)
    {
        List<BankOnboardingStepContract> result = new List<BankOnboardingStepContract>();

        BankOnboardingStepFullInfo prevStep = await _onboardingStateMachine.GetPrevStep(context, currentStep.Sid);
        while (prevStep != null && prevStep.Step != EBankOnboardingStep.Dashboard)
        {
            result.Add(new BankOnboardingStepContract
            {
                Id = prevStep.Step,
                Sid = prevStep.Sid,
            });
            prevStep = await _onboardingStateMachine.GetPrevStep(context, prevStep.Sid);
        }

        result.Reverse();

        return result;
    }
    
    public async Task<List<BankOnboardingStepContract>> After(Guid currentStepSid)
    {
        List<BankOnboardingStepContract> result = new List<BankOnboardingStepContract>();
        await AddPreviousStepsAsync(currentStepSid, result);
        result.Reverse();
        return result;
    }

    private async Task AddPreviousStepsAsync(Guid currentStepSid, List<BankOnboardingStepContract> result)
    {
        BankOnboardingStepFullInfo prevStep = await _onboardingStateMachine.GetPrevStep(context, currentStepSid);
        if (prevStep != null && prevStep.Step != EBankOnboardingStep.Dashboard)
        {
            result.Add(new BankOnboardingStepContract
            {
                Id = prevStep.Step,
                Sid = prevStep.Sid,
            });
            await AddPreviousStepsAsync(prevStep.Sid, result);
        }
    }
    */
}