using h_work.lesson15.example1;

namespace h_work.lesson15.example2;

public class ExactLegalRepMatch : OnboardingLegalRepMatch
{
    public Guid LegalRepPersonId { get; set; }
    public override OnboardingLegalRepMatchType Type => OnboardingLegalRepMatchType.ExactMatch;
}

public class NoLegalRepMatch : OnboardingLegalRepMatch
{
    public override OnboardingLegalRepMatchType Type => OnboardingLegalRepMatchType.Empty;
}

public class MultiRepMatch : OnboardingLegalRepMatch
{
    public override OnboardingLegalRepMatchType Type => OnboardingLegalRepMatchType.MultiMatches;
}

public abstract class OnboardingLegalRepMatch
{
    public abstract OnboardingLegalRepMatchType Type { get; }
}

public enum OnboardingLegalRepMatchType
{
    Empty = 0,
    MultiMatches = 1,
    ExactMatch = 2
}


public class ConnectLegalRepresentativeServiceV2
{
    private readonly IOnboardingLegalRepsService _legalRepsService;

    public ConnectLegalRepresentativeServiceV2(IOnboardingLegalRepsService legalRepsService)
    {
        _legalRepsService = legalRepsService;
    }

    public async Task Execute(ExactLegalRepMatch match)
    {
        ITestBankOnboardingContext context = null;

        var legal = await _legalRepsService.GetById(match.LegalRepPersonId);
    }
}

public class Example
{
    private readonly ConnectLegalRepresentativeServiceV2 _serviceV2;
    private readonly ITestBankOnboardingMetadataService _onboardingMetadata;

    public Example(ConnectLegalRepresentativeServiceV2 serviceV2, ITestBankOnboardingMetadataService onboardingMetadata)
    {
        _serviceV2 = serviceV2;
        _onboardingMetadata = onboardingMetadata;
    }

    public async Task Test()
    {
        ITestBankOnboardingContext context = null;

        //по хорошему надо вынести отдельно работу с матчами и создание из метаданных, но это уже отдельная история оставлю здесь

        var legalMatch = await _onboardingMetadata.GetKey<OnboardingLegalRepresentativesMatch>(context, "LegalRepMatch");

        //данный матч просто будет передаваться как переменная в камунду и явно передаваться в сервис вместо того чтобы браться из метаданных
        ExactLegalRepMatch match = new ExactLegalRepMatch();

        await _serviceV2.Execute(match);
    }
}