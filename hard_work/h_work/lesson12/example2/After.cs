namespace h_work.lesson12.example2;

public record ActiveAobBanner(Guid CompanyId, Guid? UserId);
public interface IAobBannerV2
{
    Task<ActiveAobBanner> GetLastActive(Guid companyId, Guid userId);
    //предусловие есть активный баннер (!=null)
    
    Task Deactivate(ActiveAobBanner activeBanner);
}