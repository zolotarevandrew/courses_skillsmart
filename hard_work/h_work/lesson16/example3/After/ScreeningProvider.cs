namespace h_work.lesson16.example3.After;


public record ScreeningId(string Value);

public record ScreeningResult(ScreeningId Id, ScreeningHitsGroup Hits)
{
    public bool IsEmpty => Hits.Value.Count == 0;
};

public record AsyncScreeningResult(ScreeningId Id);

public record ReadyAsyncScreening(ScreeningId Id);

public record ScreeningHitsGroup(List<ScreeningHit> Value);
public record ScreeningHit(string Id, ScreeningHitType Type);

public enum ScreeningHitType
{
    NegativeNews,
    Sanctions
}

//считаем что нам всегда нужны все хиты (не добавляем в запросы), а фильтровать будет получатель
public record StartOrganizationScreening(Guid Id, string Name, string CountryCode);
public record StartPersonScreening(Guid Id, string Name, string CountryCode, DateTime? DateOfBirth = null);

//асинхронный провайдер скрининга
public interface IAsyncScreeningProvider
{
    Task<AsyncScreeningResult> AsyncStartForOrganization(StartOrganizationScreening start);
    Task<AsyncScreeningResult> AsyncStartForPerson(StartPersonScreening start);

    Task<ReadyAsyncScreening> CheckReady(AsyncScreeningResult screeningResult);
    Task<ScreeningResult> GetReady(ReadyAsyncScreening ready);
    
    //только асинхронный провайдера скрининга поддерживаются мониторинг хитов
    Task PutToOngoingMonitoring(ScreeningId screeningId);
}

//синхронный провайдер скрининга
public interface ISyncScreeningProvider
{
    Task<ScreeningResult> SyncStartForOrganization(StartOrganizationScreening start);
    Task<ScreeningResult> SyncStartForPerson(StartPersonScreening start);
}


//разные провайдеры могут иметь и только синхронные или только асинхронные методы или все вместе, отделяем это на конкретного провайдера
//считаем что все системы имеют возможность резолюцию хитов

public record ScreeningHitResolution
{
    public ScreeningHitResolutionType Type { get; }
    public string Comment { get; }

    private ScreeningHitResolution(ScreeningHitResolutionType type)
    {
        Type = type;
    }
    private ScreeningHitResolution(ScreeningHitResolutionType type, string comment)
    {
        Type = type;
        Comment = comment;
    }
    
    public static ScreeningHitResolution CreateFalsePositive(string comment) => new ScreeningHitResolution(ScreeningHitResolutionType.FalsePositive);
    public static ScreeningHitResolution CreateTruePositive() => new ScreeningHitResolution(ScreeningHitResolutionType.TruePositive);
    public static ScreeningHitResolution CreateTruePositiveWithComment(string comment) => new ScreeningHitResolution(ScreeningHitResolutionType.TruePositive);
}

public enum ScreeningHitResolutionType
{
    FalsePositive,
    TruePositive
}

public interface IScreeningProvider
{
    Task MarkHitResolution(ScreeningHit hit, ScreeningHitResolution resolution);
    Task MarkHitGroupResolution(ScreeningHitsGroup hitGroup, ScreeningHitResolution resolution);
}

//используем явного провайдера через фабрику
public interface IScreeningProviderFactory
{
    ISomeSystemScreeningProvider GetSomeSystemProvider();
}

public interface ISomeSystemScreeningProvider : 
    IScreeningProvider, 
    ISyncScreeningProvider, 
    IAsyncScreeningProvider
{
    
}

public class SomeSystemScreeningProvider : ISomeSystemScreeningProvider
{
    public Task<ScreeningResult> SyncStartForOrganization(StartOrganizationScreening start)
    {
        throw new NotImplementedException();
    }

    public Task<ScreeningResult> SyncStartForPerson(StartPersonScreening start)
    {
        throw new NotImplementedException();
    }

    public Task<AsyncScreeningResult> AsyncStartForOrganization(StartOrganizationScreening start)
    {
        throw new NotImplementedException();
    }

    public Task<AsyncScreeningResult> AsyncStartForPerson(StartPersonScreening start)
    {
        throw new NotImplementedException();
    }

    public Task<ReadyAsyncScreening> CheckReady(AsyncScreeningResult screeningResult)
    {
        throw new NotImplementedException();
    }

    public Task<ScreeningResult> GetReady(ReadyAsyncScreening ready)
    {
        throw new NotImplementedException();
    }

    public Task PutToOngoingMonitoring()
    {
        throw new NotImplementedException();
    }

    public Task PutToOngoingMonitoring(ScreeningId screeningId)
    {
        throw new NotImplementedException();
    }

    public Task MarkHitResolution(ScreeningHit hit, ScreeningHitResolution resolution)
    {
        throw new NotImplementedException();
    }

    public Task MarkHitGroupResolution(ScreeningHitsGroup hitGroup, ScreeningHitResolution resolution)
    {
        throw new NotImplementedException();
    }
}