using KingdomStrategy.Domain.Armies;
using KingdomStrategy.Domain.Armies.Troops;

namespace KingdomStrategy.Domain.Kingdoms;

public class KingdomArmy : Army
{
    public KingdomArmy(TroopList troops) : base(troops)
    {
    }
}