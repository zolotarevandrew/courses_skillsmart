using KingdomStrategy.Domain.Kingdoms;

namespace KingdomStrategy.UseCases;

public interface IUseCase
{
    Task Run();
}

public abstract class KingdomUseCase : IUseCase
{
    public async Task Run()
    {
        Kingdom kingdom = await GetKingdom();
        await RunCase(kingdom);
    }

    protected abstract Task RunCase(Kingdom kingdom);

    protected async Task<Kingdom> GetOtherKingdom()
    {
        return null;
    }
    
    private async Task<Kingdom> GetKingdom()
    {
        throw new NotImplementedException();
    }
}