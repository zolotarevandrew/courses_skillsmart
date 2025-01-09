namespace h_work.lesson87.Example1;

public abstract class InternalState
{
    private Enum _value;
    protected InternalState(Enum value)
    {
        _value = value;
    }
}

public class SpecificMachineState : InternalState
{
    public enum State
    {
        BusinessDetailsFilled,
    }
    
    public SpecificMachineState(State value) : base(value)
    {
    }
}

public record InternalStepV2
{
    private readonly EBankOnboardingStep? _step;
    private readonly InternalState? _state;

    private InternalStepV2(EBankOnboardingStep step)
    {
        _step = step;
        _state = null;
    }

    private InternalStepV2(InternalState state)
    {
        _state = state;
        _step = null;
    }

    public static InternalStepV2 FromStep(EBankOnboardingStep step) => new(step);
    public static InternalStepV2 FromState(InternalState state) => new(state);

    public TResult Match<TResult>(Func<EBankOnboardingStep, TResult> stepHandler, Func<InternalState, TResult> stateHandler) =>
        _step.HasValue ? stepHandler(_step.Value) : stateHandler(_state!);
}