using KingdomStrategy.Infrastructure.Storage.Interfaces;

namespace KingdomStrategy.Domain.Armies.Troops;

public record TroopState : State
{
    public TroopState(
        Health health, 
        TroopSize size, 
        AttackPower attackPower, 
        DefensePower defencePower, 
        Level level, TroopType type)
    {
        Health = health;
        Size = size;
        AttackPower = attackPower;
        DefencePower = defencePower;
        Level = level;
        Type = type;
    }

    public TroopType Type { get; set; }
    public Health Health { get; set; }
    public AttackPower AttackPower { get; set; }
    public DefensePower DefencePower { get; set; }
    public TroopSize Size { get; set; }
    public Level Level { get; set; }
}