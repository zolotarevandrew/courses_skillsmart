namespace h_work.lesson4.example2.After.Parameters;

public class CompanyTradeNameScreeningParameter : ScreeningParameter
{
    public CompanyTradeNameScreeningParameter(
        Guid companyId, 
        string tradeName) : base(companyId, companyId)
    {
        ScreeningValue = tradeName;
    }
    
    public override string ScreeningValue { get; }
    public override EEntityType EntityType => EEntityType.Company;
    public override EParameterType Type => EParameterType.CompanyTradingName;
}