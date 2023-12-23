namespace h_work.lesson31.example1;

public interface ILegalRepresentativesMatchingService
{
    Task<MatchResult> MatchAsync(UserForMatch user, LegalRepresentative legalRep);
}

public class MatchResult
{
    public bool DateMatch { get; init; }
    public bool NameMatch { get; init; }
}

public class LegalRepresentative
{
    public Guid Id { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public DateTime? BirthDate { get; init; }
}

public class UserForMatch
{
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public DateTime? BirthDate { get; init; }
}