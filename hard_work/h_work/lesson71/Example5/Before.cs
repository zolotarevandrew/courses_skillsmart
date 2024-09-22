using System.Data;

namespace h_work.lesson71.Example5;

public class CompanyIndustryInStorage{}
public class DossierQuestionnaireEditionContext{}
public class BizDataCompanyActivityContract {}
public class IndustryInStorage{}
public class CompanyLoadedDocumentIndustry {}

public class OnboardingBusinessDictionaryOption
{
}

public interface IIndustryProcessor
{
    Task<(List<CompanyIndustryInStorage> Total, CompanyIndustryInStorage Main)> ProcessCompanyIndustries(Guid companyId,
        List<BizDataCompanyActivityContract> activities, DossierQuestionnaireEditionContext context);
    Task<(List<CompanyIndustryInStorage> Total, CompanyIndustryInStorage Main)> ProcessCompanyIndustries(Guid companyId,
        OnboardingBusinessDictionaryOption option, DossierQuestionnaireEditionContext context);

    Task<List<IndustryInStorage>> ProcessIndustries(IReadOnlyCollection<BizDataCompanyActivityContract> activities, string countryCode);
    Task<List<IndustryInStorage>> ProcessIndustries(IReadOnlyCollection<CompanyLoadedDocumentIndustry> rawCompanyIndustries, string countryCode);

    Task Save(IDbConnection dbConnection, IDbTransaction dbTransaction, IReadOnlyCollection<CompanyIndustryInStorage> companyIndustries);
    Task Save(IDbConnection dbConnection, IDbTransaction dbTransaction, Guid companyId, IReadOnlyCollection<string> activityDescription);
    Task Save(IDbConnection dbConnection, IDbTransaction dbTransaction, IReadOnlyCollection<IndustryInStorage> industries);
}