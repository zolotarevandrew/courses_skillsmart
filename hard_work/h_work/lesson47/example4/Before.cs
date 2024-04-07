namespace h_work.lesson47.example4;

/*
public interface IRelatedDocumentsService
{
    Task<RelatedDocument?> GetById(Guid documentId);

    Task<ActiveDocumentsGroup> GetActive(
        DocumentRelation relation,
        params EDocumentType[] documentTypes);

    Task<ActiveDocument> GetLastActiveOrDefault(
        DocumentRelation relation,
        EDocumentType documentType);

    public Task<ActiveDocument> Add(
        DocumentRelation relation,
        Document document,
        params TemporaryFile[] files);

    Task AddFiles(Guid documentId, params TemporaryFile[] temporaryFiles);
    Task RemoveFiles(Guid documentId, params Guid[] fileIds);
}
 
public class DocExample
{
    protected override async Task SaveData(DataPointSubmitContext context, GewerbescheinDataPointSubmit submitData)
    {
        var storedDoc = await _relatedDocumentsService.GetLastActiveOrDefault(
            DocumentRelation.Company(context.CompanyId),
            DocumentInitiator.ByUser(context.UserId),
            EDocumentType.Gewerbeschein);
        var tempFiles = MapToFileListField(submitData);
        if (storedDoc is null)
        {
            await _relatedDocumentsService.Add(
                DocumentRelation.Company(context.CompanyId),
                new Document(EDocumentType.Gewerbeschein, DocumentInitiator.ByUser(context.UserId)),
                tempFiles);
        }
        else
        {
            await _relatedDocumentsService.AddFiles(storedDoc.Id, tempFiles);
        }
    }
}
*/