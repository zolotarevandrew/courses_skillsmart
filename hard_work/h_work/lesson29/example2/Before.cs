using h_work.lesson18.part1.example2;
using h_work.lesson9.example1;

namespace h_work.lesson29.example2;

public interface IFinomOnboardingLegalRepresentativesService
{
    Task<FinomOnboardingLegalRepresentative> GetById(Guid id);
    Task<List<FinomOnboardingLegalRepresentative>> GetByOnboarding(Guid onboardingId);

    Task<FinomOnboardingLegalRepresentative> Create(IBankOnboardingContext context, CreateFinomOnboardingLegalRepresentative legal);
}

public class CreateFinomOnboardingLegalRepresentative
{
    public Guid? Id { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public DateTime? BirthDate { get; init; }
    public string CountryCode { get; init; }
    public string Position { get; init; }
    public ETypeOfLegalRepresentation TypeOfRepresentation { get; init; }
}

public class FinomOnboardingLegalRepresentative
{
}

public interface IFinomOnboardingLegalRepresentativesDeclarationService
{
    Task DeleteLegal(Guid id);
    Task AddLegal(IBankOnboardingContext context, LegalDeclaredData data);
    Task UpdateLegal(IBankOnboardingContext context, LegalDeclaredData data);
    Task<List<LegalDeclaredData>> GetByOnboarding(IBankOnboardingContext context);
}

public class LegalDeclaredData
{
    public Guid? PersonId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public ETypeOfLegalRepresentation? TypeOfRepresentation { get; set; }
    public string CountryCode { get; set; }
    public string City { get; set; }
    public string Address { get; set; }
    public string PostCode { get; set; }
    public string Street { get; set; }
    public string StreetNo { get; set; }
    public bool IsCurrentUser { get; set; }
    public bool IsAllowDelete { get; set; }
    public bool IsAllowEdit { get; set; }
}