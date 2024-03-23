namespace h_work.lesson45;

public class RelatedDocument {}

public class ActiveDocument
{
    public EDocumentType Type { get; set; }
}
public class DocumentRelation {}
public enum EDocumentType {}
public class Document {}
public class TemporaryFile {}

public class UploadDocumentFilesContract {}

public interface IRelatedDocumentsService
{
    Task<RelatedDocument?> GetById(Guid documentId);

    Task<ActiveDocument?> GetLastActiveOrDefault(DocumentRelation relation, EDocumentType documentType);

    Task UploadDocumentFiles(UploadDocumentFilesContract dataContract);

    public Task<ActiveDocument> Add(
        DocumentRelation relation,
        Document document,
        params TemporaryFile[] files);
}

public class InactiveDocument
{
    public EDocumentType Type { get; set; }
}

public class DocumentsGroup
{
    private readonly List<ActiveDocument> _documents;
    private readonly List<InactiveDocument> _inactiveDocuments;

    public DocumentsGroup(List<ActiveDocument> documents, List<InactiveDocument> inactiveDocuments)
    {
        _documents = documents;
        _inactiveDocuments = inactiveDocuments;
    }
    
    public ActiveDocument? LastActive(EDocumentType documentType)
    {
        return _documents.FirstOrDefault(x => x.Type == documentType);
    }
    
    public ActiveDocument? LastActive()
    {
        return _documents.FirstOrDefault();
    }
    
    public InactiveDocument? LastInactive(EDocumentType documentType)
    {
        return _inactiveDocuments.FirstOrDefault(x => x.Type == documentType);
    }
    
    public InactiveDocument? LastInactive()
    {
        return _inactiveDocuments.FirstOrDefault();
    }
}

public interface IRelatedDocumentsV2Service
{
    Task<RelatedDocument?> GetById(Guid documentId);

    Task<DocumentsGroup> GetRelated(DocumentRelation relation, params EDocumentType[] documentTypes);

    Task UploadDocumentFiles(UploadDocumentFilesContract dataContract);

    public Task<ActiveDocument> Add(
        DocumentRelation relation,
        Document document,
        params TemporaryFile[] files);
}