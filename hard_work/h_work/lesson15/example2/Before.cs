using h_work.lesson15.example1;

namespace h_work.lesson15.example2;

public interface ITestBankOnboardingMetadataService
{
    Task<T> GetKey<T>(ITestBankOnboardingContext context, string key);
}

public class OnboardingLegalRepresentativesMatch
{
    public bool HasMultiMatchesWithUser { get; set; }
    public bool IsEmpty { get; set; }

    public bool HasExactMatch { get; set; }
    public Guid? ExactMatchPersonId { get; set; }
}

public interface IOnboardingLegalRepsService
{
    Task<OnboardingLegalRep> GetById(Guid personId);
}

public class OnboardingLegalRep
{

}

public class ConnectLegalRepresentativeService
{
    private readonly ITestBankOnboardingMetadataService _onboardingMetadata;
    private readonly IOnboardingLegalRepsService _legalRepsService;

    public ConnectLegalRepresentativeService(ITestBankOnboardingMetadataService onboardingMetadata, IOnboardingLegalRepsService legalRepsService)
    {
        _onboardingMetadata = onboardingMetadata;
        _legalRepsService = legalRepsService;
    }

    public async Task Execute()
    {
        ITestBankOnboardingContext context = null;
        var legalMatch = await _onboardingMetadata.GetKey<OnboardingLegalRepresentativesMatch>(context, BankOnboardingDataKeys.Finom.LegalRepresentativesMatch);

        if (!legalMatch.HasExactMatch)
            throw new OnboardingInconsistentStateException(context, "had no exact match");

        var legal = await _legalRepsService.GetById(legalMatch.ExactMatchPersonId.Value);
        if (legal == null)
            throw new OnboardingInconsistentStateException(context, "user was not found");

    }
}