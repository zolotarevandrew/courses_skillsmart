using KingdomStrategy.Domain.Armies.Troops;
using KingdomStrategy.Infrastructure;
using KingdomStrategy.Infrastructure.Storage.Interfaces;

namespace KingdomStrategy.Domain.Armies.Implementations;

public class Archers : Troop
{
    private readonly StateStore<TroopState> _store;

    public Archers(IMediator mediator, StateStore<TroopState> store, TroopState state) : base(mediator, TroopType.Archers, state)
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
        State.AttackPower = State.AttackPower.Increase(new AttackPower(10));
        State.DefencePower = State.DefencePower.Increase(new DefensePower(10));
        return Task.CompletedTask;
    }

    protected override Level MaxLevel => new Level(10);
}