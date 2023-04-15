using KingdomStrategy.Domain.Kingdoms;
using KingdomStrategy.Infrastructure.Storage;

namespace KingdomStrategy;

public class Worker : BackgroundService
{
    private readonly KingdomStorage _storage;

    public Worker(KingdomStorage storage)
    {
        _storage = storage;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await _storage.GetByRef(new KingdomRef("123", "Test"));
        await Task.Delay(1000000, stoppingToken);
    }
}