using KingdomStrategy.Infrastructure.Storage.Interfaces;

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

public record BuildingState : State
{
    public BuildingState(Level level)
    {
        Level = level;
    }

    public Level Level { get; private set; }
}

public interface Building
{
    BuildingType Type { get; }
    Level Level { get; }
    ModernizeResult ModernizeResult { get; }
    RunWorkProcessResult RunWorkProcessResult { get; }

    Task RunWorkProcess();
    Task Modernize();
}

public abstract class Building<TState> : StateStorable<TState>, Building 
    where TState : BuildingState
{
    public BuildingType Type { get; private set; }

    protected Building(BuildingType type, TState state) : base(state)
    {
        Type = type;

        RunWorkProcessResult = RunWorkProcessResult.None;
        ModernizeResult = ModernizeResult.None;
    }

    public Level Level => State.Level;
    
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
        await SaveState();
        RunWorkProcessResult = RunWorkProcessResult.Ok;
    }

    //предусловие, не превышен максимально доступный уровень
    //постусловие, здание модифицировано характеристики улучшены
    public async Task Modernize()
    {
        if (State.Level == MaxLevel)
        {
            ModernizeResult = ModernizeResult.LevelTooHigh;
            return;
        }
        
        State.Level.Up();
        await InternalModernize();
        await SaveState();
        ModernizeResult = ModernizeResult.Ok;
    }
    
    protected abstract bool CanRunWorkProcess();
    protected abstract Task InternalRunWorkProcess();
    protected abstract Task InternalModernize();
    protected abstract Level MaxLevel { get; }
    
}