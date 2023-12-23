namespace h_work.lesson31.example1;

public interface IPersonMatcher
{
    Task<PersonMatchResult> MatchAsync(IPerson person1, IPerson person2);
}

public class PersonMatchResult
{
    public bool DateMatch { get; init; }
    public bool NameMatch { get; init; }
    public int NamesMatchPercent { get; init; }
}


public interface IPerson
{
    string FirstName { get; }
    string LastName { get; }
    DateTime? BirthDate { get; }
}