using h_work.lesson15.example1;
using h_work.lesson15.example2;

namespace h_work.lesson15.example3;

public class OnboardingRegistrator
{

}


public class PrepareUserVerificationsV1
{
    private async Task TryCreateVerifications(ITestBankOnboardingContext context, OnboardingRegistrator registrator)
    {
        var legalsForVerification = await GetLegalsForVerification(context, registrator);
        if (!legalsForVerification.Any()) throw new OnboardingInconsistentStateException(context, "No legals found to create verifications");

    }

    private async Task<List<OnboardingLegalRep>> GetLegalsForVerification(ITestBankOnboardingContext context, OnboardingRegistrator registrator)
    {
        throw new NotImplementedException();
    }
}