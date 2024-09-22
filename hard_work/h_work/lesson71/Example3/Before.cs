namespace h_work.lesson71.Example3;

public record DataCollectionContext();

public record FinomRemindDataCollectionMessage();
public enum EDataCollectionType {}

public interface IDataCollectionFacade
{
    Task<bool> StartProcess(
        DataCollectionContext context,
        EDataCollectionType dataCollectionType,
        DateTime startInitialTimerAt);
    
    Task Remind(FinomRemindDataCollectionMessage message);
    Task ForceRemind(Guid dataCollectionId, DateTime? lastRemindAt);
    Task ExceedDeadline(Guid dataCollectionId);
    
    Task OnBlockWallet(Guid dataCollectionId);
    Task OnUnblockWallet(Guid dataCollectionId);
    
    Task Provided(Guid dataCollectionId);
    Task Complete(Guid dataCollectionId);
    Task Cancel(Guid dataCollectionId, string message);
    Task CloseAccount(Guid dataCollectionId);
    Task SendAnalyticsDataCollectionReminder(Guid dataCollectionId);

    Task DataPointReInitEvent(Guid dataPointId);
    Task DataPointProvidedEvent(Guid dataCollectionId, Guid dataPointId);
    Task CompleteDataPoint(Guid dataPointId);
}