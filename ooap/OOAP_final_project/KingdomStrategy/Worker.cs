using KingdomStrategy.Infrastructure.Kingdoms;

namespace KingdomStrategy;

public class Worker : BackgroundService
{
    private readonly KingdomSeed _seed;

    public Worker(KingdomSeed seed)
    {
        _seed = seed;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await _seed.Seed();
    }
}