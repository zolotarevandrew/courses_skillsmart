using KingdomStrategy.Infrastructure.Storage.Interfaces;

namespace KingdomStrategy.Domain.Resources.Implementations;

public class KingdomResourceManager : ResourceManager
{
    private readonly StateStore<ResourceManagerState> _store;

    public KingdomResourceManager(StateStore<ResourceManagerState> store, ResourceManagerState state) : base(state)
    {
        _store = store;
    }

    protected override StateStore<ResourceManagerState> GetStore()
    {
        return _store;
    }
}