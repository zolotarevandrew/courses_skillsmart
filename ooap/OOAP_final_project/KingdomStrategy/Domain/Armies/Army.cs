using KingdomStrategy.Domain.Armies.Troops;

namespace KingdomStrategy.Domain.Armies;
public interface IArmyDefendStrategy
{
    Task Execute(Army army);
    int ExecuteResult { get; }
}

public interface IArmyAttackStrategy
{
    Task Execute(Army army);
    int ExecuteResult { get; }
}

public abstract class Army : Any
{
    protected TroopList Troops;
    
    protected Army(TroopList troops)
    {
        Troops = troops;
    }
    
    //предусловие, стратегия защиты успешно применена
    //постусловие, для всех войск применена стратегия защиты
    public async Task DefendByStrategy(IArmyDefendStrategy defendStrategy)
    {
        DefendByStrategyResult = 1;
    }
    
    //предусловие, стратегия атаки успешно применена
    //постусловие, для всех войск применена стратегия атаки
    public async Task AttackByStrategy(IArmyAttackStrategy strategy)
    {
        AttackByStrategyResult = 1;
    }
    
    //предусловие, хотя бы одно войско может атаковать противника
    //постусловие, войска атакуют противника 
    public async Task Attack(Army army)
    {
        AttackResult = 1;
    }
    
    public int AttackResult { get; protected set; }
    public int DefendByStrategyResult { get; protected set; }
    public int AttackByStrategyResult { get; protected set; }
}