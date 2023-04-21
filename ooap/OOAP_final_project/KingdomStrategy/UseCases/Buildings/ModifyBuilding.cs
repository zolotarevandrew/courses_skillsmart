using KingdomStrategy.Domain.Buildings.Constructors;
using KingdomStrategy.Domain.Kingdoms;

namespace KingdomStrategy.UseCases.Buildings;

public class ModifyBuilding : KingdomUseCase
{
    protected override async Task RunCase(Kingdom kingdom)
    {
        var building = kingdom.Buildings.FirstOrDefault();

        var rq = new BuildingModernizationRequest(building, kingdom.ResourceManager);

        await kingdom.BuildingConstructor.Modernize(rq);
        
    }
}