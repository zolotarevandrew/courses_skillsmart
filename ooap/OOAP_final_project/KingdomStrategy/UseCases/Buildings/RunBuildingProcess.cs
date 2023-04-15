using KingdomStrategy.Domain.Buildings;
using KingdomStrategy.Domain.Kingdoms;
using Xunit;

namespace KingdomStrategy.UseCases.Buildings;

public class RunBuildingProcess : KingdomUseCase
{
    protected override async Task RunCase(Kingdom kingdom)
    {
        var building = kingdom.Buildings.FirstOrDefault();
        Assert.NotNull(building);

        await building.RunWorkProcess();
        Assert.Equal(building.RunWorkProcessResult, RunWorkProcessResult.Ok);
    }
}