using KingdomStrategy.Domain.Kingdoms;
using KingdomStrategy.Domain.Resources;
using Xunit;

namespace KingdomStrategy.UseCases.Resources;

public class ConsumeResource : KingdomUseCase
{
    protected override async Task RunCase(Kingdom kingdom)
    {
        await kingdom.ResourceManager.Consume(null);
        Assert.Equal(kingdom.ResourceManager.ConsumeResult, ConsumeResult.Ok);
    }
}