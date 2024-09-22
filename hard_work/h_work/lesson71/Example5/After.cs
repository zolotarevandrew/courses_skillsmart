namespace h_work.lesson71.Example5;

public record RawIndustry(string Code, string Description, bool IsMain);

public interface IIndustryCreator
{
    Task<(List<CompanyIndustryInStorage> Other, CompanyIndustryInStorage Main)> Create(
        Guid companyId,
        List<RawIndustry> activities,
        DossierQuestionnaireEditionContext context
    );
}

public interface IIndustryTranslator
{
    Task<List<IndustryInStorage>> Translate(IReadOnlyCollection<RawIndustry> activities, string countryCode);
}