namespace h_work.lesson3.before;

public enum EPersonVerificationMatchType
{
    Full = 1,
    NamesMatched = 2,
    DatesMatched = 3,
    Mismatched = 4,
}

public class PersonVerificationMatch
{
    public EPersonVerificationMatchType Type { get; }

    public PersonVerificationMatch(EPersonVerificationMatchType type)
    {
        Type = type;
    }
}

public interface IPersonVerificationMatchService
{
    Task<PersonVerificationMatch> Match(Guid personId);
}
public class PersonVerificationMatchService : IPersonVerificationMatchService
{
    static Dictionary<Func<(PersonVerificationMatchResponse Match, FinomVerificationConfig Config), bool>, EPersonVerificationMatchType> MatchTypes = new()
    {
        { (m) => m.Match.NamesMatchPercent == m.Config.PersonVerificationFullMatchPercent && m.Match.IsDatesOfBirthMatched, EPersonVerificationMatchType.Full },
        { (m) => m.Match.NamesMatchPercent < m.Config.PersonVerificationFullMatchPercent && m.Match.IsDatesOfBirthMatched, EPersonVerificationMatchType.DatesMatched },
        { (m) => m.Match.NamesMatchPercent >= m.Config.PersonVerificationAlmostMatchPercent && !m.Match.IsDatesOfBirthMatched, EPersonVerificationMatchType.NamesMatched }
    };

    private readonly IVerificationDataOuterService _outerService;
    private readonly FinomVerificationConfig _config;

    public PersonVerificationMatchService(IVerificationDataOuterService outerService, FinomVerificationConfig config)
    {
        _outerService = outerService;
        _config = config;
    }

    public async Task<PersonVerificationMatch> Match(Guid personId)
    {
        var match = await _outerService.GetPersonVerificationMatch(personId);

        var matchedKey = MatchTypes.Keys
            .FirstOrDefault(key => key((match, _config)));

        if (matchedKey != null)
        {
            return new PersonVerificationMatch(MatchTypes[matchedKey]);
        }

        return new PersonVerificationMatch(EPersonVerificationMatchType.Mismatched);
    }
}

public interface IVerificationDataOuterService
{
    Task<PersonVerificationMatchResponse> GetPersonVerificationMatch(Guid personId);
}

public class PersonVerificationMatchResponse
{
    public int NamesMatchPercent { get; set; }
    public bool IsDatesOfBirthMatched { get; set; }
}

public class FinomVerificationConfig
{
    public int PersonVerificationAlmostMatchPercent { get; set; } = 95;
    public int PersonVerificationFullMatchPercent { get; set; } = 100;
}