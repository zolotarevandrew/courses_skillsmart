namespace h_work.lesson18.part3.example1;

public record StepTransitionContext();

public enum EBankOnboardingStep
{

}
public interface IStepTransitionMachine
{
    string Export(StepTransitionContext context);
    Task<EBankOnboardingStep?> GetStep<TContext>(TContext context) where TContext : StepTransitionContext;
}

public record StepTransitionsGroup(List<StepTransition> Transitions)
{
    public override string ToString()
    {
        return string.Join(", ", Transitions.Select( c => "From: " + c.From + " To: " + c.To));
    }
};

public record StepTransition(EBankOnboardingStep From, EBankOnboardingStep To);

public interface IStepTransitionMachineV2
{
    StepTransitionsGroup Export(StepTransitionContext context);
    Task<EBankOnboardingStep?> GetStep<TContext>(TContext context) where TContext : StepTransitionContext;
}