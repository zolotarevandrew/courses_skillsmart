namespace h_work.lesson71.Example3;

public interface IDataCollectionReminder
{
    Task Remind(Guid dataCollectionId, DateTime? lastRemindAt);
    Task ForceRemind(Guid dataCollectionId, DateTime? lastRemindAt);
}

public interface IDataCollectionAccountBlocks
{
    Task Block(Guid dataCollectionId);
    Task Unblock(Guid dataCollectionId);
    Task Close(Guid dataCollectionId);
}

public interface IDataCollectionState
{
    Task<bool> Start(
        DataCollectionContext context,
        EDataCollectionType dataCollectionType,
        DateTime startInitialTimerAt);
    
    Task Complete(Guid dataCollectionId);
    Task Cancel(Guid dataCollectionId, string message);
    Task Provide(Guid dataCollectionId);
    Task ExceedDeadline(Guid dataCollectionId);
}


public interface IDataCollectionPoints
{
    Task ReInit(Guid dataPointId);
    Task Provide(Guid dataCollectionId, Guid dataPointId);
    Task Complete(Guid dataPointId);
}