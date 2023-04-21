using KingdomStrategy.Domain.Buildings;
using KingdomStrategy.Domain.Buildings.Constructors;
using KingdomStrategy.Domain.Kingdoms;
using KingdomStrategy.Infrastructure.Kingdoms;

namespace KingdomStrategy.UseCases.Kingdoms;

public class ConstructBuilding : ByKingdomUseCase
{
    public ConstructBuilding(KingdomLoader loader, ILogWriter logWriter) : base(loader, logWriter)
    {
    }
    
    public override string Name => "Construct building by kingdom ";
    public override int Command => 5;
    public override string Help => "Construct building by kingdom id, pass id after, example = 5 \"6442ab3a525f04222ff135d2\" \"LumberMull\" or \"GoldMine\"";

    protected override async Task RunCase(Kingdom kingdom, params string[] args)
    {
        var type = args[0];
        if (!Enum.TryParse<BuildingType>(type, out var parsed))
        {
            LogWriter.Write("Invalid type (LumberMull,GoldMine ) available");
            return;
        }
        var request = new BuildingConstructionRequest(
            parsed,
            kingdom.ResourceManager
        );
        await kingdom.BuildingConstructor.Construct(request);
        
        var constructed = kingdom.BuildingConstructor.GetConstructed();
        var state = constructed.GetState();
        LogWriter.Write($"Result - {kingdom.BuildingConstructor.ConstructResult.ToString()}, level - {state.Level.Value}, id - {state.Id}");
    }
}