namespace KingdomStrategy.Domain.Armies.Troops;

public interface ITroopDefendStrategy
{
    Task Execute(Troop troop);
    int ExecuteResult { get; }
}

public interface ITroopAttackStrategy
{
    Task Execute(Troop troop);
    int ExecuteResult { get; }
}

public enum TroopType
{
    Archers = 1,
    Infantry = 2,
    Cavalry = 3,
}

public abstract class Troop : Any
{
    protected TroopState State;
    
    private ITroopDefendStrategy _defendStrategy;
    private ITroopAttackStrategy _attackStrategy;

    protected Troop(TroopState state)
    {
        State = state;
    }

    //предусловие, стратегия защиты успешно применена
    //постусловие, защита увеличена
    public async Task DefendByStrategy(ITroopDefendStrategy defendStrategy)
    {
        _defendStrategy = defendStrategy;
        DefendByStrategyResult = 1;
    }

    //предусловие, стратегия атаки успешно применена
    //постусловие, сила атаки увеличена
    public async Task AttackByStrategy(ITroopAttackStrategy attackStrategy)
    {
        _attackStrategy = attackStrategy;
        AttackByStrategyResult = 1;
    }

    //предусловие, достаточно ресурсов для атаки (в том числе можно считать на основе данных атакующего типа и тп)
    //постусловие, здоровье оппонента уменьшено
    public async Task Attack(Troop target)
    {
        if (!CanAttack(target))
        {
            AttackResult = 1;
            return;
        }
        
        AttackResult = 0;
    }
    
    public abstract bool CanAttack(Troop target);
    
    //предусловие, доступна возможность тренировки (возможно уже максимально тренированы)
    //постусловие, уровень тренированности (атака/защита/здоровья увеличены)
    public async Task Train()
    {
        //TODO подумать над уровнями тренированности далее
        TrainResult = 1;
    }
    
    public int DefendByStrategyResult { get; protected set; }
    public int AttackByStrategyResult { get; protected set; }
    public int AttackResult { get; protected set; }
    public int TrainResult { get; protected set; }
}