using h_work.lesson18.part1.example2;

namespace h_work.lesson94.Example1;

public enum OnboardingPersonType
{
    Registrar,
    AdditionalLegalRepresentative
}

public record OnboardingPerson(Guid Id, OnboardingPersonType Type, Guid UserId);
public interface IOnboardingPersonService
{
    Task<OnboardingPerson> GetById(IBankOnboardingContext context, Guid id);
}

public class DocumentSigningService(IOnboardingPersonService onboardingPersonService)
{
    
    private Task<OnboardingPerson> GetOnboardingPerson(
        IBankOnboardingContext context, Guid personId)
    {
        //далее крутим логику на основе типа персоны.
        return onboardingPersonService.GetById(context, personId);
    }
}