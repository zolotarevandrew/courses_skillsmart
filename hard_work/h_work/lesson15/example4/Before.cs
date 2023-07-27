namespace h_work.lesson15.example4;


public enum OnboardingStep
{

}


public class Before
{


    public async Task<OnboardingStep?> NextStep(OnboardingStep currentStep)
    {
        OnboardingStep? step = null;

        if (step.HasValue && step == currentStep)
        {
            /*var ex = new OnboardingInconsistentStateException(context, "IFlowMachineService.Next error");
            await _dependencies.Logger.Error(context, _source, "NextStepError", ex);*/

            step = null;
        }

        return step;
    }
}
