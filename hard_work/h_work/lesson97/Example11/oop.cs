public interface IBannerSortStrategy
{
    IEnumerable<AobBanner> Sort(IEnumerable<AobBanner> banners);
}

public class AobBanner();

public class MigrationBannerSortStrategy : IBannerSortStrategy
{
    public IEnumerable<AobBanner> Sort(IEnumerable<AobBanner> banners)
    {
        throw new NotImplementedException();
    }
}

public class BasicBannerSortStrategy : IBannerSortStrategy
{
    public IEnumerable<AobBanner> Sort(IEnumerable<AobBanner> banners)
    {
        throw new NotImplementedException();
    }
}

public class GermanyBannerSortStrategy : IBannerSortStrategy
{
    public IEnumerable<AobBanner> Sort(IEnumerable<AobBanner> banners)
    {
        throw new NotImplementedException();
    }
}