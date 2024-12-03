namespace h_work.lesson83;

/*
public class PersonVerificationCheckDuplicateService : IPersonVerificationCheckDuplicateService
{
    private readonly IFeatureToggleHelper _featureToggleHelper;
    private readonly IIdCheckOuterService _idCheckOuterService;

    public PersonVerificationCheckDuplicateService(
        IFeatureToggleHelper featureToggleHelper,
        IIdCheckOuterService idCheckOuterService)
    {
        _featureToggleHelper = featureToggleHelper;
        _idCheckOuterService = idCheckOuterService;
    }

    public async Task<PersonVerificationDuplicate> Check(RequestPersonVerificationDuplicate request)
    {
        bool needSkip = await _featureToggleHelper.IsAvailableAsync(EFeatures.SkipCheckDuplicateVerification, request.UserId);
        if (needSkip)
        {
            return new PersonVerificationDuplicate(false, new List<PersonDuplicate>());
        }

        var similarApplicants = await _idCheckOuterService.SumSubSimilarApplicants(
            new SumSubSimilarApplicantSearchRequest
            {
                PersonId = request.PersonId
            });

        if (!similarApplicants.IsSuccess)
        {
            throw new InvalidOperationException($"Similar applicants search failed {similarApplicants.Message} userId {request.UserId}");
        }

        var found = similarApplicants.Results.Count > 0;
        var persons = similarApplicants.Results
            .Select(x => new PersonDuplicate { PersonId = x.PersonId })
            .ToList();
        return new PersonVerificationDuplicate(found, persons);
    }
}
*/