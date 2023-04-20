using KingdomStrategy.Domain.Resources;
using KingdomStrategy.Domain.Resources.Implementations;
using KingdomStrategy.Infrastructure.Storage.Interfaces;

namespace KingdomStrategy.Domain.Buildings.Implementations;

public record LumberMillState : BuildingState
{
    public ResourceQuantity Produced { get; private set; }
    public Wood Wood { get; private set; }

    public LumberMillState(
        Level level, 
        Wood wood, 
        ResourceQuantity produced) : base(level)
    {
        Wood = wood;
        Produced = produced;
    }

    public void Farm()
    {
        Wood.AddQuantity(Produced);
    }

    public void Modernize()
    {
        var newQuantity = new ResourceQuantity((uint)10 * Level.Value);
        Produced += newQuantity;
    }
}
public class LumberMill : Building<LumberMillState>
{
    private readonly StateStore<LumberMillState> _store;
    private static readonly Level MaxLvl = new(5);
    
    public LumberMill(StateStore<LumberMillState> store, LumberMillState state) : base(BuildingType.LumberMill, state)
    {
        _store = store;
    }

    protected override bool CanRunWorkProcess()
    {
        return true;
    }

    protected override Task InternalRunWorkProcess()
    {
        State.Farm();
        return Task.CompletedTask;
    }

    protected override Task InternalModernize()
    {
        State.Modernize();
        return Task.CompletedTask;
    }

    protected override Level MaxLevel => MaxLvl;
    protected override StateStore<LumberMillState> GetStore()
    {
        return _store;
    }
}