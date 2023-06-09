namespace h_work.lesson7.Before;

public record TicketRelatedEntity
{
    public string EntityId { get; set; }
    public List<TicketRelatedEntityProperty> Properties { get; init; } = new();
    public EEntityType EntityType { get; set; }
    public ERelatedType RelatedType { get; set; }
}

public class TicketRelatedEntityProperty
{
    public ERelatedEntityPropertyType PropertyType { get; set; }
    public string Value { get; set; }
}

public enum ERelatedEntityPropertyType
{
    BusinessName,
    CountryOfIncorporation,
    FullName,
    CompanyRole,
    CountryOfResidence,
    LegalForm
}

public enum EEntityType
{
    Company,
    Person,
    LegalEntity
}

public enum ERelatedType
{
    LegalRepresentatives,
    Shareholders,
    Ubos
}