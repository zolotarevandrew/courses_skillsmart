namespace h_work.lesson26.second_part.example3;

public record ActiveAobBanner(Guid CompanyId, Guid? UserId, EAobBannerType Type);

public enum EAobBannerType
{
}

public interface IAobBanner
{
    Task<ActiveAobBanner> GetLastActive(Guid companyId, Guid userId);
    Task Deactivate(ActiveAobBanner activeBanner);
}

