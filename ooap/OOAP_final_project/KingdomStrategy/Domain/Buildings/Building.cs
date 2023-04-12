namespace KingdomStrategy.Domain.Buildings;

public interface IBuildingWorkProcessStrategy
{
    Task Execute(Building building);
    int ExecuteResult { get; }
}
public abstract class Building : Any
{
    public BuildingType Type { get; private set; }
    private BuildingCapacity _capacity;

    protected Building(
        BuildingType type, 
        BuildingCapacity capacity)
    {
        Type = type;
        _capacity = capacity;
    }

    //предусловие, возможно запустить рабочий процесс
    //постусловие, стратегия рабочего процесса успешно применена
    //постусловие, рабочий процесс запущен
    public async Task RunWorkProcess(IBuildingWorkProcessStrategy strategy)
    {
        if (!CanRunWorkProcess())
        {
            RunWorkProcessResult = 1;
            return;
        }
        
        RunWorkProcessResult = 0;
        await InternalRunWorkProcess();
    }

    //предусловие, возможно модифицировать здание (не превышен максимально доступный уровень)
    //постусловие, здание модифицировано емкость/вместимость увеличена
    public async Task Modernize()
    {
        //todo
        ModernizeResult = 0;
    }

    protected abstract bool CanRunWorkProcess();
    protected abstract Task InternalRunWorkProcess();
    
    public int ModernizeResult { get; private set; }
    public int RunWorkProcessResult { get; private set; }
}