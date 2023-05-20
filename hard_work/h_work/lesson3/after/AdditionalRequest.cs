using Newtonsoft.Json.Linq;

namespace h_work.lesson3.after;

public class OnboardingContext
{
    public Guid CompanyId { get; set; }
    public Guid UserId { get; set; }
}
public class CreateOnboardingAdditionalRequest
{
    public OnboardingContext Context { get; init; }
    public JObject Metadata { get; init; }
}

public abstract class OnboardingAdditionalRequest
{
    public abstract Task Create(CreateOnboardingAdditionalRequest request);
}

public interface IBannerService
{
    Task Upsert(UpsertBanner upsertBanner);
}

public class UpsertBanner
{
    public Guid CompanyId { get; set; }
    public Guid UserId { get; set; }
    public EBannerStatus NewStatus { get; set; }
    public EBannerState NewAobState { get; set; }
    public JObject Metadata { get; set; }
    public BannerType Type { get; set; }
}

public enum BannerType
{
    DetailsMismatch = 2
}

public abstract class ByAobBannerAdditionalRequest : OnboardingAdditionalRequest
{
    private readonly IBannerService _bannerService;

    protected abstract BannerType BannerType { get; }

    protected ByAobBannerAdditionalRequest(IBannerService bannerService)
    {
        _bannerService = bannerService;
    }

    public override async Task Create(CreateOnboardingAdditionalRequest request)
    {
        var context = request.Context;
        await _bannerService.Upsert(new UpsertBanner
        {
            Type = BannerType,
            CompanyId = context.CompanyId,
            UserId = context.UserId,
            NewStatus = EBannerStatus.Active,
            NewAobState = EBannerState.Normal,
            Metadata = request.Metadata
        });
        await CreateInternal(request);
    }

    protected abstract Task CreateInternal(CreateOnboardingAdditionalRequest request);
}

public enum EBannerState
{
    Normal
}

public enum EBannerStatus
{
    Active
}
