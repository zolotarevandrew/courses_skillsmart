namespace h_work.lesson4.example2.After.Parameters;

public class PersonFullNameScreeningParameter : ScreeningParameter
{
    private readonly string _firstName;
    private readonly string _lastName;

    public PersonFullNameScreeningParameter(
        Guid companyId, 
        CompanyPerson companyPerson) : base(companyId, companyPerson.Id)
    {
        _firstName = companyPerson.FirstName;
        _lastName = companyPerson.LastName;
        
        PersonType = EPersonType.None;
        if (companyPerson.IsLegalRepresentative)
        {
            PersonType |= EPersonType.LegalRepsentative;
        }
        if (companyPerson.IsBeneficiary)
        {
            PersonType |= EPersonType.Ubo;
        }
        if (companyPerson.IsShareholder)
        {
            PersonType |= EPersonType.Shareholder;
        }
    }
    
    public EPersonType PersonType { get; }
    public override string ScreeningValue => $"{_firstName} {_lastName}";
    public override EEntityType EntityType => EEntityType.Person;
    public override EParameterType Type => EParameterType.PersonFullName;
}