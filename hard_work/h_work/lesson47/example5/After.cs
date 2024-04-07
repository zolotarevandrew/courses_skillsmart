using h_work.lesson45;

namespace h_work.lesson47.example5;

public class RelatedCompany
{
    public Guid CompanyId { get; init; }
    public EBankCode Bank { get; init; }
}

public enum EBankCode
{
    
}

public enum EDocumentRelationType
{
    Company,
    Person,
    Questionnaire
}

public abstract class DocumentRelation
{
    private readonly Guid _id;
    public Guid Id { get; }
    public abstract EDocumentRelationType Type { get; }

    protected DocumentRelation(Guid id)
    {
        _id = id;
    }
    
}

public class CompanyDocumentRelation : DocumentRelation, IDocumentCompanyRelation
{
    
    public override EDocumentRelationType Type => EDocumentRelationType.Company;
    public CompanyDocumentRelation(Guid id) : base(id)
    {
    }

    public async Task<List<RelatedCompany>> Get(IServiceProvider provider)
    {
        throw new NotImplementedException();
        //var context = await provider.Get<IBankOnboardingService>.TryGetLast(Id);
        //return context.BankCode;
    }
}

public class PersonDocumentRelation : DocumentRelation, IDocumentCompanyRelation
{
    public PersonDocumentRelation(Guid id) : base(id)
    {
    }

    public override EDocumentRelationType Type => EDocumentRelationType.Person;
    
    public Task<List<RelatedCompany>> Get(IServiceProvider provider)
    {
        throw new NotImplementedException();
        // var person = await provider.Get<IBankOnboardingPersonService>.Get(personId);
        //var context = await provider.Get<IBankOnboardingService>.GetById(person.OnboardingId);
        //return new[] { context.CompanyId };
    }
}



public class QuestionnaryDocumentRelation : DocumentRelation, IDocumentCompanyRelation
{
    public QuestionnaryDocumentRelation(Guid id) : base(id)
    {
    }

    public override EDocumentRelationType Type => EDocumentRelationType.Questionnaire;
    public Task<List<RelatedCompany>> Get(IServiceProvider provider)
    {
        throw new NotImplementedException();
    }
}

public interface IDocumentCompanyRelation
{
    //тут сервис провайдер надо заменить на специфичный IDocumentCompanyRelationServiceProvider, не стал усложнять описание
    Task<List<RelatedCompany>> Get(IServiceProvider provider);


/*

public class After
{
    
    private async Task<List<RelatedCompany>> GetCompanies(DocumentRelation relation)
    {
        //(relation as IDocumentCompanyRelation).Get(provider);
    }
}

*/