using KingdomStrategy.Domain.Kingdoms;
using KingdomStrategy.Domain.Resources;
using Xunit;

namespace KingdomStrategy.UseCases.Resources;

public class PutResource : KingdomUseCase
{
    protected override async Task RunCase(Kingdom kingdom)
    {
        await kingdom.ResourceManager.Put(null);
        
    }
}