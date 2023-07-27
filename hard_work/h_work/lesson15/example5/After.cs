namespace h_work.lesson15.example5;

public abstract class BannerV2
{
    public Guid CompanyId { get; set; }
    public Guid UserId { get; set; }
    public EBannerType Type { get; set; }
    public abstract EBannerStatus Status { get; }
}

public class ActiveBanner : BannerV2
{
    public override EBannerStatus Status => EBannerStatus.Active;
}

public class DisabledBanner : BannerV2
{
    public override EBannerStatus Status => EBannerStatus.Disabled;
}


public class After
{
    private readonly IBannerService _bannerService;

    public After(IBannerService bannerService)
    {
        _bannerService = bannerService;
    }

    public async Task Deactivate(ActiveBanner banner)
    {
        await _bannerService.Upsert(new UpsertBanner(banner.CompanyId, banner.UserId, banner.Type, EBannerStatus.Disabled)
        {

        });
        //other logic
    }
}
