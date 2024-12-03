namespace h_work.lesson83;

/*
public class MigrationStatusResponse
{
    public EMigrationStatus Status { get; set; }
}

public enum EMigrationStatus
{
    NotStarted = 0,
    Started = 1,
}

public class GetMigrationStatusRequestHandler(
        IBankOnboardingContextService onboardingContextService)
    : InternalOutRequestHandler<MigrationStatusResponse>
{
    [HttpGet("migration/status/{companyId}")]
    public override async Task<MigrationStatusResponse> Handle()
    {
        var companyId = RouteValues.GetRoute<Guid>("companyId");
        var context = await onboardingContextService.TryGetLast(companyId);
        if (!context.IsPartnerMigration())
        {
            return new MigrationStatusResponse
            {
                Status = EMigrationStatus.NotStarted
            };
        }

        return new MigrationStatusResponse
        {
            Status = EMigrationStatus.Started
        };
    }
}
*/