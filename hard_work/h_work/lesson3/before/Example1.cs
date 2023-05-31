using h_work.lesson5.example3;

namespace h_work.lesson3.before;

public class PersonVerificationDuplicate
{
    public List<PersonDuplicate> Persons { get;}
    public bool Found { get; }

    public PersonVerificationDuplicate(bool found, List<PersonDuplicate> duplicates)
    {
        Found = found;
        Persons = duplicates;
    }
}
public class PersonDuplicate
{
    public Guid PersonId { get; init; }
}

public class RequestPersonVerificationDuplicate
{
    public Guid PersonId { get; init; }
    public Guid UserId { get; init; }
}

public interface IPersonVerificationCheckDuplicateService
{
    Task<PersonVerificationDuplicate> Check(RequestPersonVerificationDuplicate request);
}

public class PersonVerificationCheckDuplicateService : IPersonVerificationCheckDuplicateService
{
    private readonly IFeatureToggle _featureToggle;
    private readonly IIdCheckOuterService _idCheckOuterService;

    public PersonVerificationCheckDuplicateService(
        IFeatureToggle featureToggle,
        IIdCheckOuterService idCheckOuterService)
    {
        _featureToggle = featureToggle;
        _idCheckOuterService = idCheckOuterService;
    }

    public async Task<PersonVerificationDuplicate> Check(RequestPersonVerificationDuplicate request)
    {
        bool needSkip = await _featureToggle.IsAvailableAsync("SkipCheckDuplicateVerification", request.UserId);
        if (needSkip)
        {
            return new PersonVerificationDuplicate(false, new List<PersonDuplicate>());
        }

        var similarApplicants = await _idCheckOuterService.SimilarApplicants(
            new SimilarApplicantSearchRequest
            {
                PersonId = request.PersonId
            });

        var found = similarApplicants.Results.Count > 0;
        var persons = similarApplicants.Results
            .Select(x => new PersonDuplicate { PersonId = x.PersonId })
            .ToList();
        return new PersonVerificationDuplicate(found, persons);
    }
}

public interface IIdCheckOuterService
{
    Task<SimilarApplicantSearchResponse> SimilarApplicants(SimilarApplicantSearchRequest request);
    Task<Response> ImitateVerification(ImitateVerificationRequestContract sumSubContract);
    Task<Response> MarkCompleted(ApplyPersonVerificationRequest request);
}

public class Response
{
    public string Error { get; set; }
}

public class SimilarApplicantSearchRequest
{
    public Guid PersonId { get; init; }
}

public class SimilarApplicantSearchResponse
{
    public List<SimilarApplicantDto> Results { get; set; } = new();
}

public class SimilarApplicantDto
{
    public Guid PersonId { get; set; }
}

public interface IFeatureToggle
{
    Task<bool> IsAvailableAsync(string feature, Guid userId);
}