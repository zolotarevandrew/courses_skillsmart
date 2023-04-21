using KingdomStrategy.Domain.Buildings;
using KingdomStrategy.Domain.Buildings.Constructors;
using KingdomStrategy.Domain.Kingdoms;

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
        

        var building = kingdom.BuildingConstructor.GetConstructed();
        
        
    }
}