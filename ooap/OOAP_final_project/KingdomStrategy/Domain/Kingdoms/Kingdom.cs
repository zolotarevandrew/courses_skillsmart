using System.Resources;
using KingdomStrategy.Domain.Armies;
using KingdomStrategy.Domain.Buildings;
using KingdomStrategy.Domain.Buildings.Constructors;

namespace KingdomStrategy.Domain.Kingdoms;

public class Kingdom : Any
{
    public string Name { get; init; }
    public Kingdom(
        string name,
        Army army, 
        BuildingList buildings, 
        BuildingConstructorList constructors, 
        ResourceManager resourceManager)
    {
        Name = name;
        Army = army;
        Buildings = buildings;
        Constructors = constructors;
        ResourceManager = resourceManager;
    }

    public Army Army { get; init; }
    public BuildingList Buildings { get; init; }
    public BuildingConstructorList Constructors { get; init; }
    public ResourceManager ResourceManager { get; init; }
}