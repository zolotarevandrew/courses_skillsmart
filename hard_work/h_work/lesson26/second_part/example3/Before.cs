namespace h_work.lesson26.second_part.example3;


public class AobBannerInStorage
{
    public Guid CompanyId { get; set; }
    public Guid UserId { get; set; }
    public EAobBannerType Type { get; set; }
    public DateTime Created { get; set; }
    public bool Enabled { get; set; }
}

public interface IAobBannerStorageService
{
    Task<List<AobBannerInStorage>> Get(Guid companyId, Guid? userId);
    Task Upsert(AobBannerInStorage aobBannerInStorage);
}
