namespace h_work.lesson16.example1.After;

public interface IOnboardingPersonsService
{
    Lazy<IBankOnboardingBeneficiariesService> Beneficiaries { get; }
    Lazy<IBankOnboardingLegalRepsService> LegalReps { get; }

    Task MarkAsRegistrator(OnboardingPerson person, Guid userId);
    Task<OnboardingRegistator> GetRegistrator(Guid onboardingId);
}

public record Shares(decimal Value);

public record CreateOnboardingBeneficiary(string FirstName, string LastName, Shares Shares);
public interface IBankOnboardingBeneficiariesService
{
    Task Add(CreateOnboardingBeneficiary request);
    Task<OnboardingBeneficiar> Get(Guid id);
    Task<List<OnboardingBeneficiar>> GetByOnboarding(Guid onboardingId);
    Task ChangeShares(OnboardingBeneficiar beneficiar, Shares shares);
}


public record CreateOnboardingLegalRep(string FirstName, string LastName, LegalRepType Type);
public interface IBankOnboardingLegalRepsService
{
    Task Add(CreateOnboardingLegalRep request);
    Task<OnboardingLegalRep> Get(Guid id);
    Task<List<OnboardingLegalRep>> GetByOnboarding(Guid onboardingId);
    Task ChangePhone(OnboardingLegalRep legalRep, FromOnboardingPhone phone);
}

public record FromOnboardingPhone(string Code, string Number);