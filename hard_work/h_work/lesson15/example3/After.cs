using h_work.lesson15.example1;
using h_work.lesson15.example2;

namespace h_work.lesson15.example3;

public class OnboardingVerificationsList
{
    private List<OnboardingLegalRep> _legalsForVerification;
    public OnboardingVerificationsList(OnboardingLegalRep legalRep)
    {
        Add(legalRep);
    }

    public void Add(OnboardingLegalRep rep)
    {
        _legalsForVerification ??= new List<OnboardingLegalRep>();

        if (rep == null) throw new ArgumentNullException("legalRep");

        _legalsForVerification.Add(rep);
    }
}


public class PrepareUserVerificationsV2
{
    private async Task TryCreateVerifications(ITestBankOnboardingContext context, OnboardingRegistrator registrator)
    {
        var legalsForVerification = await GetLegalsForVerification(context, registrator);

    }

    private async Task<OnboardingVerificationsList> GetLegalsForVerification(ITestBankOnboardingContext context, OnboardingRegistrator registrator)
    {
        throw new NotImplementedException();
    }
}