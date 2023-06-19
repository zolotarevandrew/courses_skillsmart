using Newtonsoft.Json;

namespace h_work.lesson9.example1.After;

public record LegalRepresentativeInBusiness
{
    public string BusinessId { get; set; }
    public ETypeOfLegalRepresentation TypeOfLegalRepresentation { get; set; }
}

public class LegalRepresentativePerson
{
    private const string MetadataKey = "LegalRepresentativeInBusinesses";
    
    private readonly CompanyPersonInStorage _personInStorage;

    public LegalRepresentativePerson(CompanyPersonInStorage personInStorage)
    {
        //or create static factory function
        if (!personInStorage.IsLegalRepresentative) throw new InvalidOperationException("not lr");
        _personInStorage = personInStorage;
    }

    public void AddInBusinessRelation(LegalRepresentativeInBusiness relation)
    {
        var currentRelations = GetInBusinessRelations();
        if (currentRelations.Any(b => b == relation)) return;

        currentRelations.Add(relation);
        _personInStorage.Metadata[MetadataKey] = JsonConvert.SerializeObject(currentRelations);
    }
    
    List<LegalRepresentativeInBusiness> GetInBusinessRelations()
    {
        var businesses = _personInStorage.Metadata?.GetValueOrDefault<List<LegalRepresentativeInBusiness>>(MetadataKey);
        return businesses ?? new List<LegalRepresentativeInBusiness>();
    }
}