namespace KingdomStrategy.Infrastructure.Storage.Interfaces;

public abstract class StateStore<TState> where TState: State
{
    public abstract Task Save(TState state);
}

public record State
{
    public string Id { get; protected set; }
}

public abstract class StateStorable<TState> : Any where TState: State
{
    protected TState State;

    protected StateStorable(TState state)
    {
        State = state;
    }

    protected async Task SaveState()
    {
        var store = GetStore();
        await store.Save(State);
    }

    protected abstract StateStore<TState> GetStore();
}