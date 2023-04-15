using KingdomStrategy.Domain.Kingdoms;
using KingdomStrategy.Domain.Resources;
using Xunit;

namespace KingdomStrategy.UseCases.Resources;

public class ConsumePoolResources : KingdomUseCase
{
    protected override async Task RunCase(Kingdom kingdom)
    {
        await kingdom.ResourceManager.ConsumePool(new ResourcePool(new List<Resource>
        {

        }));
        Assert.Equal(kingdom.ResourceManager.ConsumePoolResult, ConsumePoolResult.Ok);
    }
}