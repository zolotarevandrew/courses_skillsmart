using KingdomStrategy.Domain.Kingdoms;
using KingdomStrategy.Infrastructure.Kingdoms;

namespace KingdomStrategy.UseCases.Kingdoms;

public class ShowAllResources : ByKingdomUseCase
{
    public ShowAllResources(KingdomLoader loader, ILogWriter logWriter) : base(loader, logWriter)
    {
    }
    
    public override string Name => "All resources by kingdom ";
    public override int Command => 3;
    public override string Help => "Getting all resources info by kingdom id, pass id after, example = 3 \"6442ab3a525f04222ff135d2\"";

    protected override async Task RunCase(Kingdom kingdom, params string[] args)
    {
        var resources = kingdom.ResourceManager.Get().ToList();
        if (resources.Count == 0)
        {
            LogWriter.Write($"No resources yet");
            return;
        }
        
        foreach (var resource in resources)
        {
            LogWriter.Write($"{resource.Name} quantity - {resource.Quantity.Value}");
        }
    }

    
}