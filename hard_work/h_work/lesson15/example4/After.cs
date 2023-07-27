namespace h_work.lesson15.example4;



public enum EOnboardingStep
{
    Default = 0,
    Test = 1
}

public record CurrentOnboardingStep(EOnboardingStep Value);

public record NextOnboardingStep
{
    public EOnboardingStep Value { get; }
    public NextOnboardingStep(EOnboardingStep? value, CurrentOnboardingStep currentStep)
    {
        Value = currentStep.Value == value
            ? EOnboardingStep.Default
            : value ?? EOnboardingStep.Default;
    }
}


public class After
{


    public async Task<NextOnboardingStep> NextStep(CurrentOnboardingStep currentStep)
    {
        EOnboardingStep? step = null;

        return new NextOnboardingStep(step, currentStep);
    }
}
