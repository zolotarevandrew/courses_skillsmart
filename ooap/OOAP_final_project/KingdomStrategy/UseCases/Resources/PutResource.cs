using KingdomStrategy.Domain.Kingdoms;

namespace KingdomStrategy.UseCases.Resources;

public class PutResource : KingdomUseCase
{
    protected override async Task RunCase(Kingdom kingdom)
    {
        await kingdom.ResourceManager.Put(null);
        
    }
}