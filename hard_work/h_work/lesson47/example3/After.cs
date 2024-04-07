namespace h_work.lesson47.example3;

/*
public enum EAobBannerType
{
    AdditionalQuestions,
}

public interface IAOBBannerService
{
    
}

public enum EAobBannerStatus
{
    Active = 1,
    Inactive = 2
}


public class AdditionalQuestionsAobBannerService 
{
    private readonly IAOBBannerService _bannerService;

    public AdditionalQuestionsAobBannerService(IAOBBannerService bannerService)
    {
        _bannerService = bannerService;
    }

    public Task SetHasUnansweredQuestions(Guid companyId, Guid userId)
    {
        return SetBannerInternal(companyId, userId, EAobBannerStatus.Active);
    }

    public Task SetHasNoUnansweredQuestions(Guid companyId, Guid userId)
    {
        return SetBannerInternal(companyId, userId, EAobBannerStatus.Inactive);
    }

    private async Task NotifyAobBannerStatusChanged(Guid companyId, Guid userId)
    {
        throw new NotImplementedException();
    }

    private async Task SetBannerInternal(Guid companyId, Guid userId, EAobBannerStatus status)
    {
        await _bannerService.Upsert(new UpsertBannerEntity(companyId, EAobBannerType.AdditionalQuestions)
        {
            NewStatus = setActive ? EAobBannerStatus.Active : EAobBannerStatus.Inactive,
            UserId = userId,
        });
        await NotifyAobBannerStatusChanged(companyId, userId);
    }
}
*/