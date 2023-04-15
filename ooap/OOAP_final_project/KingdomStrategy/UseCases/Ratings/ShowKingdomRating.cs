using KingdomStrategy.Domain.Kingdoms;
using KingdomStrategy.Domain.Kingdoms.Ratings;
using Xunit;

namespace KingdomStrategy.UseCases.Ratings;

public class ShowKingdomRating : KingdomUseCase
{
    private readonly KingdomLeaderboard _leaderboard;

    public ShowKingdomRating(KingdomLeaderboard leaderboard)
    {
        _leaderboard = leaderboard;
    }
    protected override async Task RunCase(Kingdom kingdom)
    {
        var rating = await _leaderboard.GetByKingdom(kingdom.Ref);
        Assert.NotNull(rating);
    }
}