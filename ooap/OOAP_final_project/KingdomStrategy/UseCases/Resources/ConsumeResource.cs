using KingdomStrategy.Domain.Kingdoms;
using KingdomStrategy.Domain.Resources;

namespace KingdomStrategy.UseCases.Resources;

public class ConsumeResource : KingdomUseCase
{
    protected override async Task RunCase(Kingdom kingdom)
    {
        await kingdom.ResourceManager.Consume(null);
    }
}