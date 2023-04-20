using KingdomStrategy.Domain.Armies.Troops;
using KingdomStrategy.Infrastructure;
using KingdomStrategy.Infrastructure.Storage.Interfaces;

namespace KingdomStrategy.Domain.Armies.Implementations;

public class Infantry : Troop
{
    private readonly StateStore<TroopState> _store;

    public Infantry(IMediator mediator, StateStore<TroopState> store, TroopState state) : base(mediator, TroopType.Infantry, state)
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
        State.AttackPower = State.AttackPower.Increase(new AttackPower(20));
        State.DefencePower = State.DefencePower.Increase(new DefensePower(10));
        return Task.CompletedTask;
    }

    protected override Level MaxLevel => new Level(10);
}