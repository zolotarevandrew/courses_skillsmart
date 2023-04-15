namespace KingdomStrategy.Domain.Armies.Troops;

public interface ITroopDefendStrategy
{
    Task Execute(Troop troop);
}

public interface ITroopAttackStrategy
{
    Task Execute(Troop troop);
}

public enum AttackResult
{
    None = 0,
    Failed = 1,
    
    Ok = 100
}

public enum TrainResult
{
    None = 0,
    LevelTooHigh = 1,
    
    Ok = 100
}

public abstract class Troop : Any
{
    protected TroopState State;
    public TroopType Type { get; private set; }

    protected Troop(TroopType type, TroopState state)
    {
        Type = type;
        State = state;

        TrainResult = TrainResult.None;
        AttackResult = AttackResult.None;
    }
    
    public AttackResult AttackResult { get; private set; }
    public TrainResult TrainResult { get; private set; }

    //постусловие, стратегия защиты успешно применена
    public async Task DefendByStrategy(ITroopDefendStrategy defendStrategy)
    {
        await defendStrategy.Execute(this);
    }

    //постусловие, стратегия атаки успешно применена
    public async Task AttackByStrategy(ITroopAttackStrategy attackStrategy)
    {
        await attackStrategy.Execute(this);
    }

    //предусловие, достаточно ресурсов для атаки (в том числе можно считать на основе данных атакующего типа и тп)
    //постусловие, здоровье оппонента уменьшено
    public async Task Attack(Troop target)
    {
        if (!CanAttack(target))
        {
            AttackResult = AttackResult.Failed;
            return;
        }

        await InternalAttack(target);
        AttackResult = AttackResult.Ok;
    }

    public abstract bool CanAttack(Troop target);
    
    //предусловие, не достигнут максимальный уровень
    //постусловие, уровень и характеристики увеличены
    public async Task Train()
    {
        if (State.Level == MaxLevel)
        {
            TrainResult = TrainResult.LevelTooHigh;
            return;
        }

        State.Level.Up();
        
        await InternalTrain();
        TrainResult = TrainResult.Ok;
    }
    
    protected abstract Task InternalAttack(Troop target);
    protected abstract Task InternalTrain();
    
    protected abstract Level MaxLevel { get; }
}