namespace h_work.lesson12.example6;

public class OnboardingUrl
{
    private readonly IGlobalInfo _globalInfo;

    public OnboardingUrl(IGlobalInfo globalInfo)
    {
        _globalInfo = globalInfo;
    }

    public Uri LivenessCheckUrl(Guid stepId, Guid companyId)
    {
        var url = new Uri(new Uri(_globalInfo.Domain), $"onboarding/personal-liveness-check/{stepId}?company={companyId}");
        return url;
    }
}