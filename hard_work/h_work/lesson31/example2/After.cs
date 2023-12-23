namespace h_work.lesson31.example2;

public interface ICompanyParametersService
{
    Task SetParameter<T>(Guid companyId, T data) where T: CompanyParameter;
    Task<CompanyParameter> GetOne(Guid companyId, CompanyParameterType type);
    Task<CompanyParameterGroup> GetGroup(Guid companyId, params CompanyParameterType[] types);
}

public class CompanyParameterGroup
{
    
}

public abstract class CompanyParameter
{
    public abstract CompanyParameterType Type { get; }
}

public enum CompanyParameterType
{
    ComplexQuestionnaire,
    PaymentInformation,
    Activity
}

public class NewComplexQuestionnaireCompanyParameter : CompanyParameter
{
    public override CompanyParameterType Type => CompanyParameterType.ComplexQuestionnaire;
}

public class PaymentInformationCompanyParameter : CompanyParameter
{
    public override CompanyParameterType Type => CompanyParameterType.ComplexQuestionnaire;
}

public class CompanyActivityParameter : CompanyParameter
{
    public override CompanyParameterType Type => CompanyParameterType.Activity;
}