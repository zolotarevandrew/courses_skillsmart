using KingdomStrategy.Domain.Buildings.Constructors;
using KingdomStrategy.Domain.Kingdoms;
using Xunit;
using ModernizeResult = KingdomStrategy.Domain.Buildings.Constructors.ModernizeResult;

namespace KingdomStrategy.UseCases.Buildings;

public class ModifyBuilding : KingdomUseCase
{
    protected override async Task RunCase(Kingdom kingdom)
    {
        var building = kingdom.Buildings.FirstOrDefault();
        Assert.NotNull(building);
        
        var rq = new BuildingModernizationRequest(building, kingdom.ResourceManager);

        await kingdom.BuildingConstructor.Modernize(rq);
        
        Assert.Equal(kingdom.BuildingConstructor.ModernizeResult, ModernizeResult.Ok);
    }
}