using KingdomStrategy.Domain.Kingdoms;
using KingdomStrategy.Infrastructure.Kingdoms;

namespace KingdomStrategy.UseCases.Kingdoms;

public class AttackOtherKingdom : ByKingdomUseCase
{
    public AttackOtherKingdom(KingdomLoader loader, ILogWriter logWriter) : base(loader, logWriter)
    {
    }
    
    public override string Name => "Attack other kingdom ";
    public override int Command => 7;
    public override string Help => "Attack other kingdom by kingdom id, opponent kingdom id, example = 7 \"6442ab3a525f04222ff135d2\" \"6442ab3a525f04222ff135d2\"";

    protected override async Task RunCase(Kingdom kingdom, params string[] args)
    {
        var id = args[0];
        var opponent = await _loader.GetByRef(new KingdomRef(id, ""));
        if (opponent == null)
        {
            LogWriter.Write("opponent not found");
            return;
        }
        await kingdom.Army.Attack(opponent.Army);
        
        LogWriter.Write($"Result - {kingdom.Army.AttackResult}");
    }
}