using KingdomStrategy.Domain.Kingdoms;

namespace KingdomStrategy.UseCases.Armies;

public class ArmyAttack : KingdomUseCase
{
    protected override async Task RunCase(Kingdom kingdom)
    {
        var army = kingdom.Army;
        var otherKingdom = await GetOtherKingdom();
        
        var opponent = otherKingdom.Army;
        await army.Attack(opponent);
    }
}