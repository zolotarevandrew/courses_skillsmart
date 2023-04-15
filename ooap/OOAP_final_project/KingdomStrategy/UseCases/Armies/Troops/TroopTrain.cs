using KingdomStrategy.Domain.Armies.Troops;
using KingdomStrategy.Domain.Kingdoms;

namespace KingdomStrategy.UseCases.Armies.Troops;

public class TroopTrain : KingdomUseCase
{
    protected override async Task RunCase(Kingdom kingdom)
    {
        var troop = GetTroop(kingdom);
        await troop.Train();
    }

    private static Troop? GetTroop(Kingdom kingdom)
    {
        var troop = kingdom.Army.Troops
            .GetAll()
            .FirstOrDefault();
        return troop;
    }
}