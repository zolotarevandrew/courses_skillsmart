namespace h_work.lesson15.example5;


public enum OnboardingStep
{

}

public class Banner
{
    public Guid CompanyId { get; set; }
    public Guid UserId { get; set; }
    public EBannerType Type { get; set; }
    public EBannerStatus Status { get; set; }
}

public interface IBannerService
{
    Task Upsert(UpsertBanner banner);
}

public record UpsertBanner(Guid CompanyId, Guid UserId, EBannerType Type, EBannerStatus status)
{

}

public enum EBannerType
{
    Test = 1
}

public enum EBannerStatus
{
    Disabled = 0,
    Active  = 1
}

public class Before
{
    private readonly IBannerService _bannerService;

    public Before(IBannerService bannerService)
    {
        _bannerService = bannerService;
    }

    public async Task Deactivate(Banner banner)
    {
        if (banner.Status != EBannerStatus.Active) throw new InvalidOperationException("banner should be active");

        await _bannerService.Upsert(new UpsertBanner(banner.CompanyId, banner.UserId, banner.Type, EBannerStatus.Disabled)
        {

        });
        //other logic
    }
}
