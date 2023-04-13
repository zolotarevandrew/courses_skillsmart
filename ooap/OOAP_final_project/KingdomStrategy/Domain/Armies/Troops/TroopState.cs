namespace KingdomStrategy.Domain.Armies.Troops;

public class TroopState
{
    public TroopState(
        Health health, 
        TroopSize size, 
        AttackPower attackPower, 
        DefensePower defencePower)
    {
        Health = health;
        Size = size;
        AttackPower = attackPower;
        DefencePower = defencePower;
    }

    public Health Health { get; init; }
    public AttackPower AttackPower { get; init; }
    public DefensePower DefencePower { get; init; }
    public TroopSize Size { get; init; }
}