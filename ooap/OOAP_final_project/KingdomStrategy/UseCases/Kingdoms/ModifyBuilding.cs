using KingdomStrategy.Domain.Buildings;
using KingdomStrategy.Domain.Buildings.Constructors;
using KingdomStrategy.Domain.Kingdoms;
using KingdomStrategy.Infrastructure.Kingdoms;

namespace KingdomStrategy.UseCases.Kingdoms;

public class ModifyBuilding : ByKingdomUseCase
{
    public ModifyBuilding(KingdomLoader loader, ILogWriter logWriter) : base(loader, logWriter)
    {
    }
    
    public override string Name => "Modify building ";
    public override int Command => 6;
    public override string Help => "Modify building by kingdom id and building id, pass id after, example = 6 \"6442ab3a525f04222ff135d2\" \"6442ab3a525f04222ff135d2\"";

    protected override async Task RunCase(Kingdom kingdom, params string[] args)
    {
        var buildingId = args[0];
        var building = kingdom.Buildings.FirstOrDefault(c => c.GetState().Id == buildingId);
        if (building == null)
        {
            LogWriter.Write("Building not found");
            return;
        }
        var request = new BuildingModernizationRequest(
            building,
            kingdom.ResourceManager
        );
        await kingdom.BuildingConstructor.Modernize(request);
        
        LogWriter.Write($"Result - {kingdom.BuildingConstructor.ModernizeResult.ToString()}");
    }
}