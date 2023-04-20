using KingdomStrategy.Domain.Resources;
using KingdomStrategy.Domain.Resources.Implementations;
using KingdomStrategy.Infrastructure.Storage.Interfaces;

namespace KingdomStrategy.Domain.Buildings.Implementations;

public record GoldMineState : BuildingState
{
    public ResourceQuantity Produced { get; private set; }
    public Gold Gold { get; private set; }

    public GoldMineState(
        Level level, 
        Gold gold, 
        ResourceQuantity produced) : base(level)
    {
        Gold = gold;
        Produced = produced;
    }

    public void Farm()
    {
        Gold.AddQuantity(Produced);
    }

    public void Modernize()
    {
        var newQuantity = new ResourceQuantity((uint)5 * Level.Value);
        Produced += newQuantity;
    }
}
public class GoldMine : Building<GoldMineState>
{
    private readonly StateStore<GoldMineState> _store;
    private static readonly Level MaxLvl = new(5);
    
    public GoldMine(StateStore<GoldMineState> store, GoldMineState state) : base(BuildingType.GoldMine, state)
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
    protected override StateStore<GoldMineState> GetStore()
    {
        return _store;
    }
}