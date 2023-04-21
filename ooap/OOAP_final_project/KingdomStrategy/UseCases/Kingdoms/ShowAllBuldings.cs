using KingdomStrategy.Domain.Kingdoms;
using KingdomStrategy.Infrastructure.Kingdoms;
using KingdomStrategy.Infrastructure.Storage;

namespace KingdomStrategy.UseCases.Kingdoms;

public class ShowAllBuildings : ByKingdomUseCase
{
    public ShowAllBuildings(KingdomLoader loader, ILogWriter logWriter) : base(loader, logWriter)
    {
    }
    
    public override string Name => "All buildings by kingdom ";
    public override int Command => 2;
    public override string Help => "Getting all buildings info by kingdom id, pass id after, example = 2 \"6442ab3a525f04222ff135d2\"";

    protected override async Task RunCase(Kingdom kingdom)
    {
        if (kingdom.Buildings.Count == 0)
        {
            LogWriter.Write($"No buildings yet");
            return;
        }
        
        foreach (var building in kingdom.Buildings)
        {
            LogWriter.Write($"{building.Type.ToString()} level - {building.Level.Value}");
        }
    }

    
}