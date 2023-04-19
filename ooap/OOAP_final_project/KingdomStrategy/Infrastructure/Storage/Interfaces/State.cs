namespace KingdomStrategy.Infrastructure.Storage.Interfaces;

public abstract class StateStore<TState> where TState: State
{
    public abstract Task Save(TState state);
}

public abstract class State {}

public abstract class StateStorable<TState> : Any where TState: State
{
    protected TState State;

    protected StateStorable(TState state)
    {
        State = state;
    }

    public async Task SaveState()
    {
        var store = GetStore();
        await store.Save(State);
    }

    public abstract StateStore<TState> GetStore();
}