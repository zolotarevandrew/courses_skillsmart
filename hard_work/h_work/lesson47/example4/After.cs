using h_work.lesson18.part3.example3;

namespace h_work.lesson47.example4;


public class ActiveDocumentsGroup
{
}

public class ActiveDocument
{
    
}


public class DocumentRelation
{
    public static DocumentRelation Company(Guid companyId)
    {
        throw new NotImplementedException();
    }
}
public class DocumentInitiator
{
    public static DocumentInitiator ByUser(Guid userId)
    {
        throw new NotImplementedException();
    }
}
public enum EDocumentType
{
    Gewerbeschein
}

public class DocumentFile
{
    
}

public class ActiveDocumentVersion
{
    public EDocumentType Type { get; init; }
    public DocumentRelation Relation { get; init; }
    public DocumentInitiator Initiator { get; init; }
    public DocumentFile[] Files { get; init; }
}

public interface IRelatedDocumentsServiceV2
{
    Task<ActiveDocumentsGroup> GetGroup(DocumentRelation relation, DocumentInitiator initiator);
    Task AddVersion(ActiveDocumentVersion version);
}

public class DocExample
{
    private readonly IRelatedDocumentsServiceV2 _relatedDocumentsService;

    public DocExample(IRelatedDocumentsServiceV2 relatedDocumentsService)
    {
        _relatedDocumentsService = relatedDocumentsService;
    }
    
    protected async Task SaveData(IBankOnboardingContext context)
    {
        await _relatedDocumentsService.AddVersion(new ActiveDocumentVersion
        {
            Type = EDocumentType.Gewerbeschein,
            //Files = MapToFileListField(submitData),
            Relation = DocumentRelation.Company(context.CompanyId),
            Initiator = DocumentInitiator.ByUser(context.UserId),
        });
    }
}
