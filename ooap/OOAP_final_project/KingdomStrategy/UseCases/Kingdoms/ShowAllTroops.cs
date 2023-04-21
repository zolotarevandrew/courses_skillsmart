using KingdomStrategy.Domain.Kingdoms;
using KingdomStrategy.Infrastructure.Kingdoms;

namespace KingdomStrategy.UseCases.Kingdoms;

public class ShowAllTroops : ByKingdomUseCase
{
    public ShowAllTroops(KingdomLoader loader, ILogWriter logWriter) : base(loader, logWriter)
    {
    }
    
    public override string Name => "All troops by kingdom ";
    public override int Command => 4;
    public override string Help => "Getting all troop info by kingdom id, pass id after, example = 4 \"6442ab3a525f04222ff135d2\"";

    protected override async Task RunCase(Kingdom kingdom, params string[] args)
    {
        var troops = kingdom.Army.Troops.GetAll().ToList();
        if (troops.Count == 0)
        {
            LogWriter.Write($"No troops yet");
            return;
        }
        
        foreach (var troop in troops)
        {
            var state = troop.GetState();
            LogWriter.Write($"{state.Type}, health - {state.Health.Value}, level - {state.Level.Value}, size - {state.Size.Value}, attackpwer - {state.AttackPower.Value}, defpower - {state.DefencePower.Value}");
        }
    }

    
}