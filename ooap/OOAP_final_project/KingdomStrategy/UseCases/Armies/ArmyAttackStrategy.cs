using KingdomStrategy.Domain.Kingdoms;

namespace KingdomStrategy.UseCases.Armies;

public class ArmyAttackStrategy : KingdomUseCase
{
    protected override async Task RunCase(Kingdom kingdom)
    {
        var army = kingdom.Army;

        await army.AttackByStrategy(null);
        
    }
}