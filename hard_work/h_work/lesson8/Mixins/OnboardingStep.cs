namespace h_work.lesson8.Mixins;

public interface IOnboarding
{
    
}
public abstract class OnboardingStep
{
    public abstract Task<object> GetData(IOnboarding onboarding);
}
public class CustomOnboardingStep : IWaitableStepMixin, IPersonalStepMixin
{

    public Task<object> GetData(IOnboarding onboarding)
    {
        var person = IPersonalStepMixin.GetPerson(onboarding);
        var status = IWaitableStepMixin.GetStatus(onboarding);
        return null;
    }
}