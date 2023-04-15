using KingdomStrategy.Domain.Armies.Troops;

namespace KingdomStrategy.Domain.Armies;

public interface IArmyDefendStrategy
{
    Task Execute(Army army);
}

public interface IArmyAttackStrategy
{
    Task Execute(Army army);
    Func<Troop, TroopList, Troop> OpponentSelector { get; }
}

public enum AttackResult
{
    None = 0,
    CantAttack = 1,
    
    Ok = 100,
}

public abstract class Army : Any
{
    public TroopList Troops { get; }

    private Func<Troop, TroopList, Troop> _opponentSelector;

    protected Army(TroopList troops)
    {
        Troops = troops;
        _opponentSelector = static (troop, troopList) =>
        {
            var all = troopList.GetAll();
            var byType = all.FirstOrDefault(c => c.Type == troop.Type);
            return byType ?? all.FirstOrDefault();
        };
        AttackResult = AttackResult.None;
    }
    
    //постусловие, для всех войск применена стратегия защиты
    public async Task DefendByStrategy(IArmyDefendStrategy defendStrategy)
    {
        await defendStrategy.Execute(this);
    }
    
    //постусловие, для всех войск применена стратегия атаки
    public async Task AttackByStrategy(IArmyAttackStrategy attackStrategy)
    {
        await attackStrategy.Execute(this);
        _opponentSelector = attackStrategy.OpponentSelector;
    }
    
    //предусловие, хотя бы одно войско может атаковать противника
    //постусловие, войска атакуют противника 
    public async Task Attack(Army army)
    {
        var canAttack = Troops
            .GetAll()
            .Select(troop =>
            {
                var opponent = _opponentSelector(troop, army.Troops);
                return troop.CanAttack(opponent);
            })
            .Any(c => c = true);

        if (!canAttack)
        {
            AttackResult = AttackResult.CantAttack;
            return;
        }
        
        foreach (var troop in Troops.GetAll())
        {
            var opponent = _opponentSelector(troop, army.Troops);
            await troop.Attack(opponent);
        }

        AttackResult = AttackResult.Ok;
    }

    public AttackResult AttackResult { get; protected set; }
}