namespace h_work.lesson4.example2.After.Parameters;

public class CompanyRegisteredNameScreeningParameter : ScreeningParameter
{
    public CompanyRegisteredNameScreeningParameter(
        Guid companyId, 
        string regName) : base(companyId, companyId)
    {
        ScreeningValue = regName;
    }
    
    public override string ScreeningValue { get; }
    public override EEntityType EntityType => EEntityType.Company;
    public override EParameterType Type => EParameterType.CompanyRegisteredName;
}