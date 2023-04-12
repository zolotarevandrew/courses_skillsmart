namespace KingdomStrategy.Domain.Armies.Troops;

public class TroopList : Any
{
    private List<Troop> _troops;

    public TroopList(List<Troop> troops)
    {
        _troops = troops;
    }

    public IEnumerable<Troop> GetAll() => _troops;

    public void Add(Troop troop)
    {
        _troops.Add(troop);
    }
}