namespace h_work.lesson32.example1;

public class LegalEntitiesByLevelService
{
    private readonly ILegalEntitiesStorage _legalEntitiesStorage;
    
    public LegalEntitiesByLevelService(ILegalEntitiesStorage legalEntitiesStorage)
    {
        _legalEntitiesStorage = legalEntitiesStorage;
    }

    public async Task<List<RegistrationNumberTreeInfo>> Get(Guid companyId, int level)
    {
        var legalRepresentatives = await _legalEntitiesStorage.GetByCompanyId(companyId);
        if (legalRepresentatives.Count == 0)
        {
            return new List<RegistrationNumberTreeInfo>();
        }

        var legalRepresentativesDictionary = legalRepresentatives
            .ToDictionary(x => x.Id, x => x);

        var result = new List<RegistrationNumberTreeInfo>();

        ProcessLevel(result, level, 1, new[] { companyId }, legalRepresentativesDictionary, new List<Guid>());
        return result;
    }

    private void ProcessLevel(
        List<RegistrationNumberTreeInfo> result,
        int needLevel,
        int currentLevel,
        Guid[] ownedBusinesses,
        Dictionary<Guid, LegalEntity> legalEntities,
        List<Guid> processedLegalEntities)
    {
        if (currentLevel > 50)
        {
            return;
        }
        
        var owners = legalEntities.Where(x => ownedBusinesses.Any(y => x.Value.ManagedBusinesses.ContainsKey(y)) &&
                                              !processedLegalEntities.Contains(x.Key))
            .Select(x => x.Value)
            .DistinctBy(x => x.Id)
            .ToList();

        processedLegalEntities.AddRange(owners.Select(x => x.Id));

        if (currentLevel < needLevel)
        {
            ProcessLevel(result, needLevel, currentLevel + 1, owners.Select(x => x.Id).ToArray(), legalEntities, processedLegalEntities);
        }
        else
        {

            foreach (var owner in owners)
            {
                result.Add(new RegistrationNumberTreeInfo
                {
                    EntityId = owner.Id,
                    CompanyName = owner.Name,
                    RegistrationNumber = owner.RegNumber,
                    Level = needLevel,
                    CountryCode = owner.CountryCode,
                });
            }
        }
    }

    
}

public class LegalEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string RegNumber { get; set; }
    public string CountryCode { get; set; }
    public Dictionary<Guid, LegalRepresentativeInBusiness> ManagedBusinesses { get; set; }
}

public interface ILegalEntitiesStorage
{
    Task<List<LegalEntity>> GetByCompanyId(Guid companyId);
}

public class RegistrationNumberTreeInfo
{
    public Guid EntityId { get; set; }
    public string CompanyName { get; set; }
    public string RegistrationNumber { get; set; }
    public int Level { get; set; }
    public string CountryCode { get; set; }
}

public class LegalRepresentativeInBusiness
{
}