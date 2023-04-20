using KingdomStrategy.Domain.Armies;
using KingdomStrategy.Domain.Buildings;
using KingdomStrategy.Domain.Buildings.Constructors;
using KingdomStrategy.Domain.Resources;
using KingdomStrategy.Infrastructure.Storage.Interfaces;

namespace KingdomStrategy.Domain.Kingdoms;


public record KingdomState : State
{
    public KingdomState(string name)
    {
        Name = name;
    }

    public string Name { get; init; }
    
    public KingdomRef Ref => new KingdomRef(Id, Name);
}
public record Kingdom
{
    private readonly KingdomState _state;

    public Kingdom(
        KingdomState state, 
        Army army, 
        ResourceManager resourceManager, 
        BuildingConstructor buildingConstructor, 
        List<Building> buildings)
    {
        _state = state;
        Army = army;
        ResourceManager = resourceManager;
        BuildingConstructor = buildingConstructor;
        Buildings = buildings;
    }

    public KingdomRef Ref => _state.Ref;
    public Army Army { get; init; }
    public BuildingConstructor BuildingConstructor { get; init; }
    public List<Building> Buildings { get; init; }
    public ResourceManager ResourceManager { get; init; }
}