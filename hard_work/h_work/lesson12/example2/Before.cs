namespace h_work.lesson12.example2;

public record AobBanner(Guid CompanyId, Guid? UserId);
public interface IAobBanner
{
    Task<AobBanner> GetActive(Guid companyId, Guid userId);
    Task Deactivate(Guid companyId, Guid userId);
}