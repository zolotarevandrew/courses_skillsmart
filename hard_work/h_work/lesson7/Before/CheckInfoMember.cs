namespace h_work.lesson7.Before;

public class CheckInfoMember
{
    public EEntityType EntityType { get; set; }
    public Guid EntityId { get; set; }
    public string Name { get; set; }
    public string Country { get; set; }
    public string Role { get; set; }
    public string LegalForm { get; set; }
    public bool IsShareholder { get; set; }
    public bool IsLegalRepresentative { get; set; }
    public bool IsBeneficiary { get; set; }
}