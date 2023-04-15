using KingdomStrategy.Domain.Kingdoms;

namespace KingdomStrategy.UseCases.Armies.Troops;

public class TroopDefendStrategy : KingdomUseCase
{
    protected override async Task RunCase(Kingdom kingdom)
    {
        var troop = kingdom.Army.Troops
            .GetAll()
            .FirstOrDefault();

        await troop.DefendByStrategy(null);
        
    }
}