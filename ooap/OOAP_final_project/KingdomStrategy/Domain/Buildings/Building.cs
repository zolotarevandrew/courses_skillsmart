namespace KingdomStrategy.Domain.Buildings;

public interface IBuildingWorkProcessStrategy
{
    Task Execute(Building building);
    int ExecuteResult { get; }
}

public enum RunWorkProcessResult
{
    None = 0,
    Busy = 1,
    
    Ok = 100,
}

public enum ModernizeResult
{
    None = 0,
    LevelTooHigh = 1,
    
    Ok = 100
}
public abstract class Building : Any
{
    public BuildingType Type { get; private set; }
    public Level Level { get; private set; }

    protected Building(
        BuildingType type,
        Level level)
    {
        Type = type;
        Level = level;

        RunWorkProcessResult = RunWorkProcessResult.None;
        ModernizeResult = ModernizeResult.None;
    }
    
    public ModernizeResult ModernizeResult { get; private set; }
    public RunWorkProcessResult RunWorkProcessResult { get; private set; }

    //предусловие, возможно запустить рабочий процесс
    //постусловие, рабочий процесс запущен
    public async Task RunWorkProcess()
    {
        if (!CanRunWorkProcess())
        {
            RunWorkProcessResult = RunWorkProcessResult.Busy;
            return;
        }
        
        await InternalRunWorkProcess();
        RunWorkProcessResult = RunWorkProcessResult.Ok;
    }

    //предусловие, не превышен максимально доступный уровень
    //постусловие, здание модифицировано характеристики улучшены
    public async Task Modernize()
    {
        if (Level == MaxLevel)
        {
            ModernizeResult = ModernizeResult.LevelTooHigh;
            return;
        }
        
        Level.Up();
        await InternalModernize();
        ModernizeResult = ModernizeResult.Ok;
    }
    
    protected abstract bool CanRunWorkProcess();
    protected abstract Task InternalRunWorkProcess();
    protected abstract Task InternalModernize();
    protected abstract Level MaxLevel { get; }
    
}