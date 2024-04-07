namespace h_work.lesson47.example3;

/*
public class AdditionalQuestionsAobBannerService 
{
    private readonly IAOBBannerService _bannerService;
    private readonly IPublisher _publisher;

    public AdditionalQuestionsAobBannerService(
        IAOBBannerService bannerService,
        IPublisher publisher)
    {
        _bannerService = bannerService;
        _publisher = publisher;
    }

    public async Task SetHasUnansweredQuestions(Guid companyId, Guid userId)
    {
        await SetBannerInternal(companyId, userId, true);
    }

    public async Task SetHasNoUnansweredQuestions(Guid companyId, Guid userId)
    {
        var banners = await _bannerService.GetActiveBanners(companyId, userId);
        if (banners != null && banners.Any(x => x.BannerType == EAobBannerType.AdditionalQuestions))
        {
            await SetBannerInternal(companyId, userId, false);
            await NotifyAobBannerStatusChanged(companyId, userId);
        }
    }

    private Task SetBannerInternal(Guid companyId, Guid userId, bool setActive)
    {
        return _bannerService.Upsert(new UpsertBannerEntity(companyId, EAobBannerType.AdditionalQuestions)
        {
            NewStatus = setActive ? EAobBannerStatus.Active : EAobBannerStatus.Inactive,
            UserId = userId,
        });
    }
}
*/