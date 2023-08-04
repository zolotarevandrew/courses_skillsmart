namespace h_work.lesson16.example1.After;

public abstract class OnboardingPerson
{
    public Guid Id { get; set; }
}

public class OnboardingRegistator : OnboardingPerson
{
    public Guid UserId { get; }
}

public class OnboardingBeneficiar : OnboardingPerson
{
    public Shares Shares { get; }
}

public enum LegalRepType
{
    Solo,
    Joint,
    Limited
}

public class OnboardingLegalRep : OnboardingPerson
{
    public LegalRepType Type { get; }
}

