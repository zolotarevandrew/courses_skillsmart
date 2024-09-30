using h_work.lesson26.second_part.example3;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace h_work.lesson72;

public interface IAobBannerService
{
    Task Upsert(UpsertBannerEntity upsertBannerEntity);
}

public enum EAobBannerStatus
{
    Active = 1,
    Inactive = 2,
}

public delegate Task ActivateBannerDelegate(AobBannerRequest request);

public record AobBannerRequest(Guid CompanyId, Guid UserId, ActivateBannerDelegate? ActivateDelegate = null);

public abstract class AobBannerActivator
{
    private readonly IAobBannerService _aobBannerService;

    protected abstract EAobBannerType BannerType { get; }
    

    protected AobBannerActivator(IAobBannerService aobBannerService)
    {
        _aobBannerService = aobBannerService;
    }

    public async Task Activate(AobBannerRequest request)
    {
        await request.ActivateDelegate?.Invoke(request);
        
        await _aobBannerService.Upsert(new UpsertBannerEntity(request.CompanyId, BannerType)
        {
            UserId = request.UserId,
            NewStatus = EAobBannerStatus.Active,
        });
    }
}

public class UpsertBannerEntity
{
    public UpsertBannerEntity(Guid requestCompanyId, EAobBannerType bannerType)
    {
        CompanyId = requestCompanyId;
        Type = bannerType;
    }

    public Guid CompanyId { get; set; }
    public Guid UserId { get; set; }
    public EAobBannerType Type { get; set; }
    public EAobBannerStatus NewStatus { get; set; }
}