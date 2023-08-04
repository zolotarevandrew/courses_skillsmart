namespace h_work.lesson16.example3.Before;

public enum EScreeningEntityType
{
    Organization = 1,
    Person = 2,
}

public record ScreeningResultSet;

//начинает скрининг
public interface IStartScreeningHelper
{
    Task<ScreeningResultSet> StartScreening(string name, string countryCode, Guid entityId, 
        bool? isOrganisation, bool isOngoing, DateTime? BirthDate, EScreeningEntityType screeningType);
}

public record SanctionList;

public record SanctionsFilter;

//поиск санкций по базе + детектор новых санкций
public interface ISanctionsHelper
{
    Task<List<SanctionList>> GetFiltered(IEnumerable<SanctionsFilter> filters);
    Task<List<SanctionList>> GetAll(bool ignoreCache = false);
    Task<List<SanctionList>> DetectNewSanctionLists();
}

//ставит сущность на мониторинг
public interface IOngoingScreeningService
{
    Task SetOngoing(string caseId, bool isOngoing);
    Task SetOngoing(Guid entityId, bool isOngoing);
}

public record ResolutionSetInternalRequest;
public record ResolutionStatus;

//ставит резолюцию хитам от скрининга
public interface IResolutionService
{
    Task SetResolution(ResolutionSetInternalRequest resoultionSetRequest);
    Task<List<ResolutionStatus>> GetRules(EScreeningEntityType screeningEntityType);
}

public record ScreeningResultOutSet;

//используется для начала скрининга, и создает кейс
public interface ICasesService
{
    Task<ScreeningResultSet> CreateOrganisation(string name, string countryCode, string groupId, Guid entityId, bool isOngoing = false);
    Task<ScreeningResultSet> CreateIndividual(string name, string groupId, Guid entityId, DateTime? birthDate = null, bool isOngoing = false);
    Task<ScreeningResultSet> CreateUnspecified(string name, string groupId, Guid entityId, bool isOngoing = false);
    Task<ScreeningResultOutSet> GetScreeningResultsByCompanyId(Guid entityId);
    Task<ScreeningResultOutSet> GetScreeningResultsByPersonId(Guid entityId);
    Task<ScreeningResultOutSet> GetScreeningResultsByEntityId(Guid entityId);
    Task<object> GetFullInfo(Guid id);
    Task<bool> UpdateCase(string systemCaseId);
}