namespace h_work.lesson8.Mixins;

public enum StepStatus
{
    Waiting = 1,
    DataReceived
}
public interface IWaitableStepMixin
{
    public static StepStatus GetStatus(IOnboarding onboarding)
    {
        return StepStatus.Waiting;
    }
}