using KingdomStrategy.Domain.Buildings;
using KingdomStrategy.Domain.Buildings.Constructors;
using KingdomStrategy.Domain.Kingdoms;
using Xunit;

namespace KingdomStrategy.UseCases.Buildings;

public class ConstructBuilding : KingdomUseCase
{
    protected override async Task RunCase(Kingdom kingdom)
    {
        var request = new BuildingConstructionRequest(
            BuildingType.LumberMill,
            kingdom.ResourceManager
        );
        await kingdom.BuildingConstructor.Construct(request);
        
        Assert.Equal(kingdom.BuildingConstructor.ConstructResult, ConstructResult.Ok);

        var building = kingdom.BuildingConstructor.GetConstructed();
        
        Assert.Equal(kingdom.BuildingConstructor.GetConstructedResult, GetConstructedResult.Ok);
        Assert.Equal(building.Type, BuildingType.LumberMill);
        
    }
}