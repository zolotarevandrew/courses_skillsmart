using KingdomStrategy.Domain.Buildings;
using KingdomStrategy.Domain.Kingdoms;

namespace KingdomStrategy.UseCases.Buildings;

public class RunBuildingProcess : KingdomUseCase
{
    protected override async Task RunCase(Kingdom kingdom)
    {
        var building = kingdom.Buildings.FirstOrDefault();

        await building.RunWorkProcess();
    }
}