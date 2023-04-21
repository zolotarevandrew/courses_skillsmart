using KingdomStrategy.Domain.Kingdoms.Ratings;

namespace KingdomStrategy.UseCases.Kingdoms;

public class ShowLeaderBoard : ConsoleUseCase
{
    private readonly KingdomLeaderboard _kingdomStorage;
    public ShowLeaderBoard(KingdomLeaderboard kingdomStorage, ILogWriter writer) : base(writer)
    {
        _kingdomStorage = kingdomStorage;
    }

    public override string Name => "Leaderboard";
    public override int Command => 0;
    public override string Help => "Show leaderboard";
    protected override async Task InternalRun(string[] args)
    {
        var all = await _kingdomStorage.GetLastLeaders();
        foreach (var state in all)
        {
            LogWriter.Write($"{state.Ref.Name}, {state.Value},  {state.Date}");
        }
    }
}