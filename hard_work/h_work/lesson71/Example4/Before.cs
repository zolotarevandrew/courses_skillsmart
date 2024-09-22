using h_work.lesson16.example1.After;
using h_work.lesson18.part1.example2;

namespace h_work.lesson71.Example4;

public record CreateOnboardingPerson();
public record ChangeOnboardingPersonRepresentation();

public interface IOnboardingPersonsService
{
    Task<OnboardingPerson> GetById(Guid id);
    Task<List<OnboardingPerson>> GetByIds(IEnumerable<Guid> ids);
    Task<List<OnboardingPerson>> GetByOnboarding(Guid onboardingId);

    Task<OnboardingPerson> TryCreate(IBankOnboardingContext context, CreateOnboardingPerson request);
    Task<OnboardingPerson> ChangeRepresentation(IBankOnboardingContext context, OnboardingPerson person, ChangeOnboardingPersonRepresentation request);
    Task<OnboardingPerson> ChangeContacts(IBankOnboardingContext context, OnboardingPerson person);
}