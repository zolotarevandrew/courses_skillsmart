using Xunit;

namespace h_work.lesson16.example3.After;

public class UseCases
{
    private readonly IScreeningProviderFactory _factory;

    public UseCases(IScreeningProviderFactory factory)
    {
        _factory = factory;
    }
    
 
    public async Task StartScreening_NoHitsFound()
    {
        var someProviderScreening = _factory.GetSomeSystemProvider();
        var startedScreening = await someProviderScreening.SyncStartForOrganization(new StartOrganizationScreening(Guid.NewGuid(), "name", "DE"));
        Assert.Equal(startedScreening.IsEmpty, true);
    }
    
    public async Task StartScreening_WithResolutions_HitsFound()
    {
        var someProviderScreening = _factory.GetSomeSystemProvider();
        var startedScreening = await someProviderScreening.SyncStartForOrganization(new StartOrganizationScreening(Guid.NewGuid(), "Vladimit Putin", "RU"));
        Assert.Equal(startedScreening.IsEmpty, false);

        foreach (var hit in startedScreening.Hits.Value)
        {
            await someProviderScreening.MarkHitResolution(hit, ScreeningHitResolution.CreateTruePositiveWithComment("thats true"));
        }
    }
    
    public async Task StartScreeningWithResolutions_HitsFound()
    {
        var someProviderScreening = _factory.GetSomeSystemProvider();
        var startedScreening = await someProviderScreening.SyncStartForOrganization(new StartOrganizationScreening(Guid.NewGuid(), "Vladimit Putin", "RU"));
        Assert.Equal(startedScreening.IsEmpty, false);

        foreach (var hit in startedScreening.Hits.Value)
        {
            await someProviderScreening.MarkHitResolution(hit, ScreeningHitResolution.CreateTruePositiveWithComment("thats true"));
        }
    }
}