namespace h_work.lesson72;

/*
 * public class FinomPartnerMigrationOnboarding
{
    public IBankOnboardingContext Current { get; init; }
    public Guid MigrationCompanyId { get; init; }

    public IBankOnboardingContext MigrationOnboarding()
    {
        return new BankOnboardingContext
        {
            //yeap buddy
            CompanyId = MigrationCompanyId,

            UserId = Current.UserId,

            OnboardingId = Current.OnboardingId,
            OnboardingType = Current.OnboardingType,
            OnboardingStatus = Current.OnboardingStatus,
            CountryCode = Current.CountryCode,
            Source = Current.Source,
            Version = Current.Version,
            CreatedAt = Current.CreatedAt,
            ModifiedAt = Current.ModifiedAt,
            CurrentStep = Current.CurrentStep,
            OnboardingState = Current.OnboardingState,
        };
    }
}

public interface IFinomPartnerMigrationOnboardingScope
{
    Task<FinomPartnerMigrationOnboarding> Get(IBankOnboardingContext current);
}

public class FinomPartnerMigrationOnboardingScope(IBankOnboardingMetadataService onboardingMetadataService)
    : IFinomPartnerMigrationOnboardingScope
{
    public async Task<FinomPartnerMigrationOnboarding> Get(IBankOnboardingContext current)
    {
        var migrationCompanyId = await onboardingMetadataService.GetKey<Guid>(current, BankOnboardingDataKeys.Finom.MigrationCompanyId);
        return new FinomPartnerMigrationOnboarding
        {
            MigrationCompanyId = migrationCompanyId,
            Current = current
        };
    }
}
*/