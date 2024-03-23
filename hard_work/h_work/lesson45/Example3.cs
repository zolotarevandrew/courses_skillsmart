namespace h_work.lesson45;

public class DataCollectionModel 
{
}

public class DataCollectionContext 
{
}

public class DataCollectionClientState {}

public class DataCollectionInfo {}

public interface IDataCollectionService
{
    Task<DataCollectionModel> Init(DataCollectionContext context, DateTime startedAt);
   
    Task<DataCollectionClientState> GetClientState(DataCollectionModel state, Guid userId, string language);
    Task<DataCollectionInfo> BuildInfo(DataCollectionModel state);
    
    Task<DataCollectionModel?> GetState(DataCollectionContext context);
    Task<DataCollectionModel?> GetState(Guid dataCollectionId);
}

public enum EDataCollectionStatus {
}

public class DataCollectionState {
    public Guid Id { get; }
    public Guid CompanyId { get; }
    public Guid UserId { get; }
    public string CountryCode { get; }
}

public abstract class DataCollection 
{
    public DataCollectionState State { get; }
    public DataPointsStates DataPoints { get; }
     
    public abstract EDataCollectionStatus CalcStatus();
    public abstract Task<string> CalcBannerText(string userLanguage);
}

public class DataPointState 
{

 
}

public class DataPointsStates {
    private List<DataPointState> _states;

    public DataPointsStates(List<DataPointState> states)
    {
        _states = states;
    }
}

public interface IDataCollectionServiceV2 
{
    Task<DataCollection> Init(DataCollectionContext context, DateTime startedAt);
    Task<DataCollection?> GetState(DataCollectionContext context);
}

