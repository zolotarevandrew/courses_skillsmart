using h_work.lesson9.example1;

namespace h_work.lesson29.example2;

public interface IFinomOnboardingLegalRepresentativesServiceV2
{
    Task<FinomOnboardingLegalRepresentative> GetById(Guid id);
    Task<List<FinomOnboardingLegalRepresentative>> GetByOnboarding(Guid onboardingId);
    
    Task<FinomOnboardingLegalRepresentative> Create(CreateFinomOnboardingLegalRepresentative legal);
    Task<FinomOnboardingLegalRepresentative> ChangePersonalData(ChangeFinomOnboardingLegalRepresentativePersonalDataV2 legal);
    
    Task RemoveById(Guid id);
}

public class CreateFinomOnboardingLegalRepresentativeV2
{
    public CreateFinomOnboardingLegalRepresentativeV2(Guid onboardingId)
    {
        OnboardingId = onboardingId;
    }
    public Guid? Id { get; init; }
    public Guid OnboardingId { get; } 
    public PersonFullName Name { get; init; }
    public DateTime? BirthDate { get; init; }
    public string Position { get; init; }
    public ETypeOfLegalRepresentation TypeOfRepresentation { get; init; }
    public Address PersonalAddress { get; init; }
}

public class ChangeFinomOnboardingLegalRepresentativePersonalDataV2
{
    public Guid Id { get; init; }
    public PersonFullName Name { get; init; }
    public Address PersonalAddress { get; init; }
}

public record PersonFullName(string FirstName, string LastName);

public class Address
{
    public string Country { get; init; }
    public string City { get; init; }
    public string Value { get; init; }
    public string PostCode { get; init; }
    public Street Street { get; init; }
}

public class Street
{
    public string Value { get; init; }
    public string Number { get; init; }
}