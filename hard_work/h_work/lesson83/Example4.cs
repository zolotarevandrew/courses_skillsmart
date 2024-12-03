namespace h_work.lesson83;

public class Example4
{
    /*
     * private async Task<bool> ShouldSkipAdditionalQuestions(Guid companyId, IBankOnboardingContext onboardingContext, UserInfoBase user)
    {
        if (onboardingContext.IsPartnerMigrationInProgress())
        {
            return true;
        }

        bool userHasMigratedCompanyEnabled = user.Companies.Any(c =>
            c.MigrationInfo?.TargetCompanyId == companyId

            //only for Silent Migration - skipping italy here..
            && c.CountryCode.In(CountryCodes.Germany, CountryCodes.France)
        );
        if (userHasMigratedCompanyEnabled) return true;

        return false;
    }
     */
}