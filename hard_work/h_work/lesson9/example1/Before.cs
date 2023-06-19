using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace h_work.lesson9.example1;

public static class Before
{
    public static void TrySetTypeOfRepresentation(BusinessRelation relation, ETypeOfLegalRepresentation typeOfRepresentation, CompanyPersonInStorage person)
    {
        if (!relation.IsLegalRepresentative) return;

        var businesses = person.GetRepresentativeInBusinesses();
            
        var business = new LegalRepresentativeInBusiness
        {
            BusinessId = relation.Id,
            TypeOfLegalRepresentation = typeOfRepresentation,
        };

        bool sameRelationExists = businesses.Any(b =>
            b.BusinessId == business.BusinessId 
            && b.TypeOfLegalRepresentation == business.TypeOfLegalRepresentation);
        if (sameRelationExists) return;

        businesses.Add(business);
        person.Metadata[MetadataKeys.LegalRepresentativeInBusinesses] = JsonConvert.SerializeObject(businesses);
    }

    public static List<LegalRepresentativeInBusiness> GetRepresentativeInBusinesses(this CompanyPersonInStorage person)
    {
        var businesses =
            person.Metadata?.GetValueOrDefault<List<LegalRepresentativeInBusiness>>(MetadataKeys
                .LegalRepresentativeInBusinesses)
            ?? new List<LegalRepresentativeInBusiness>();

        return businesses;
    }
    
    public static T GetValueOrDefault<T>(this JObject jObject, string propertyName)
    {
        var token = jObject.GetValue(propertyName, StringComparison.InvariantCultureIgnoreCase);
        if (token == null)
        {
            return default(T);
        }

        return token.ToObject<T>();
    }
}

public enum ETypeOfLegalRepresentation
{
    Full,
    Restricted
}

public class MetadataKeys
{
    public const string LegalRepresentativeInBusinesses = "LegalRepresentativeInBusinesses";
}

public class CompanyPersonInStorage
{
    public JObject Metadata { get; set; }
    public bool IsLegalRepresentative { get; set; }
}

public record LegalRepresentativeInBusiness
{
    public string BusinessId { get; set; }
    public ETypeOfLegalRepresentation TypeOfLegalRepresentation { get; set; }
}

public class BusinessRelation
{
    public bool IsLegalRepresentative { get; set; }
    public string Id { get; set; }
}