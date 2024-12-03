namespace h_work.lesson83;

/*
public class PartnerMigrationOnboarding
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

public interface IPartnerMigrationOnboardingScope
{
    Task<PartnerMigrationOnboarding> Get(IBankOnboardingContext current);
}

public class PartnerMigrationOnboardingScope(IBankOnboardingMetadataService onboardingMetadataService)
    : IPartnerMigrationOnboardingScope
{
    public async Task<PartnerMigrationOnboarding> Get(IBankOnboardingContext current)
    {
        var migrationCompanyId = await onboardingMetadataService.GetKey<Guid>(current, BankOnboardingDataKeys.MigrationCompanyId);
        return new PartnerMigrationOnboarding
        {
            MigrationCompanyId = migrationCompanyId,
            Current = current
        };
    }
}
*/