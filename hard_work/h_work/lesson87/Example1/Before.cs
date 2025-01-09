namespace h_work.lesson87;

public enum EBankOnboardingStep
{
    
}
public record InternalStepState
{
    public EBankOnboardingStep? Step { get; private set; }
    public string State { get; private set; }
    private InternalStepState(EBankOnboardingStep step)
    {
        Step = step;
        State = null;
    }

    private InternalStepState(string state)
    {
        State = state;
        Step = null;
    }
    
    public bool IsStep => Step != null;

    public static implicit operator InternalStepState(EBankOnboardingStep d) => new(d);
    public static implicit operator InternalStepState(string d) => new(d);
}