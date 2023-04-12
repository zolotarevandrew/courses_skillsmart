using System.Resources;
using KingdomStrategy.Domain.Armies;
using KingdomStrategy.Domain.Buildings;
using KingdomStrategy.Domain.Buildings.Constructors;

namespace KingdomStrategy.Domain.Kingdoms;

public class Kingdom : Any
{
    public KingdomLeader Leader { get; }
    
    public Army Army { get; set; }
    
    public List<BuildingConstructor> BuildingConstructors { get; }
    public List<Building> Buildings { get; }
    
    public ResourceManager ResourceManager { get; }
}