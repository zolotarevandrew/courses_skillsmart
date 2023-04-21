using KingdomStrategy.Infrastructure.Storage;

namespace KingdomStrategy.UseCases.Kingdoms;

public class ShowAllKingdoms : ConsoleUseCase
{
    private readonly KingdomStorage _kingdomStorage;
    public ShowAllKingdoms(KingdomStorage kingdomStorage, ILogWriter writer) : base(writer)
    {
        _kingdomStorage = kingdomStorage;
    }

    public override string Name => "All kingdoms";
    public override int Command => 1;
    public override string Help => "Getting all kingdoms";
    protected override async Task InternalRun(string[] args)
    {
        var all = await _kingdomStorage.GetAll();
        foreach (var state in all)
        {
            LogWriter.Write($"{state.Name}, {state.Id}");
        }
    }
}