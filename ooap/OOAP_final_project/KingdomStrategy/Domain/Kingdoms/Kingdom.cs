using KingdomStrategy.Domain.Armies;
using KingdomStrategy.Domain.Buildings;
using KingdomStrategy.Domain.Buildings.Constructors;
using KingdomStrategy.Domain.Resources;

namespace KingdomStrategy.Domain.Kingdoms;

public class Kingdom : Any
{
    public Kingdom(
        KingdomRef @ref, 
        Army army, 
        ResourceManager resourceManager, 
        BuildingConstructor buildingConstructor, 
        List<Building> buildings)
    {
        Ref = @ref;
        Army = army;
        ResourceManager = resourceManager;
        BuildingConstructor = buildingConstructor;
        Buildings = buildings;
    }

    public KingdomRef Ref { get; init; }
    public Army Army { get; init; }
    public BuildingConstructor BuildingConstructor { get; init; }
    public List<Building> Buildings { get; init; }
    public ResourceManager ResourceManager { get; init; }
}