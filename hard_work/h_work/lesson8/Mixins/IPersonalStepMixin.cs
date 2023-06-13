namespace h_work.lesson8.Mixins;

public class OnboardingPerson
{
    
}
public interface IPersonalStepMixin
{
    public static OnboardingPerson GetPerson(IOnboarding onboarding)
    {
        //todo
        return new OnboardingPerson();
    }
}