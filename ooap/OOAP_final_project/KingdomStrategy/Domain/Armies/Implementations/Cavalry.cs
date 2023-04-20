using KingdomStrategy.Domain.Armies.Troops;
using KingdomStrategy.Infrastructure.Storage.Interfaces;

namespace KingdomStrategy.Domain.Armies.Implementations;

public class Cavalry : Troop
{
    private readonly StateStore<TroopState> _store;

    public Cavalry(StateStore<TroopState> store, TroopState state) : base(TroopType.Cavalry, state)
    {
        _store = store;
    }

    protected override StateStore<TroopState> GetStore()
    {
        return _store;
    }

    public override bool CanAttack(Troop target)
    {
        return true;
    }

    protected override Task InternalAttack(Troop target, TroopState targetState)
    {
        var health = new Health(State.AttackPower.Value);
        targetState.Health = targetState.Health.Decrease(health);
        return Task.CompletedTask;
    }

    protected override Task InternalTrain()
    {
        State.AttackPower = State.AttackPower.Increase(new AttackPower(30));
        State.DefencePower = State.DefencePower.Increase(new DefensePower(30));
        return Task.CompletedTask;
    }

    protected override Level MaxLevel => new Level(10);
}