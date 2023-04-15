using KingdomStrategy.Domain.Armies.Troops;
using KingdomStrategy.Domain.Kingdoms;

namespace KingdomStrategy.UseCases.Armies.Troops;

public class TroopAttack : KingdomUseCase
{
    protected override async Task RunCase(Kingdom kingdom)
    {
        var troop = GetTroop(kingdom);
        var otherKingdom = await GetOtherKingdom();
        
        var opponent = GetTroop(otherKingdom);
        await troop.Attack(opponent);
        
    }

    private static Troop? GetTroop(Kingdom kingdom)
    {
        var troop = kingdom.Army.Troops
            .GetAll()
            .FirstOrDefault();
        return troop;
    }
}