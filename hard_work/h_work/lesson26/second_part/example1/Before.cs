namespace h_work.lesson26.second_part.example1;

public interface IVerifiedPersonServiceV1
{
    Task<List<UserVerifiedPersonV1>> Get(Guid userId);
}

public class UserVerifiedPersonV1 
{
    public Guid Id { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string Nationality { get; init; }
    public DateTime? DateOfBirth { get; init; }
    public string CountryOfBirth { get; init; }
    public string PlaceOfBirth { get; init; }
    public Guid Company { get; init; }
}