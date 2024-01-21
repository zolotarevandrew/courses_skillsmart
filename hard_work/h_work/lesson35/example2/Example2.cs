namespace h_work.lesson35.example2;

public class Example2
{
    private readonly IRelatedDocumentsService _relatedDocuments;

    /*
     До - сервис работы со связанными документами
     */
    public void Before()
    {
        /*
         * public async Task<DocumentInfo> StoreFile(Guid documentId, Guid entityId, string originDocType,
            EDocumentType documentType, Stream fileStream, string fileName,
            string mimetype, int? fileSize, Guid? author = null)
        {
            string filePathResult = await _documentsService.StoreFile(entityId, documentId,
                originDocType ?? documentType.ToString(), fileStream, mimetype);

            var entity = new DocumentEntity
            {
                Author = author,
                CreatedAt = DateTime.UtcNow,
                DocumentType = documentType,
                EntityId = entityId,
                FileName = fileName ?? string.Empty,
                Mimetype = mimetype,
                FileSize = fileSize,
                FilePath = filePathResult,
                Id = documentId,
                Status = EntityStatus.Active,
            };

            await _documentsStorageService.Insert(entity);

            await _publisher.PublishAsync(new DocumentUploadedMessage
            {
                DocumentId = documentId,
            });

            return Map(entity);
        }
         */
    }
    
    /*
     * После - производим рефакторинг
     */
    public interface IRelatedDocumentsService
    {
        Task<ActiveDocument?> GetById(Guid documentId);
        public Task<ActiveDocument> AddNew(
            DocumentRelation relation,
            NewDocument document,
            params TemporaryFile[] files);
    }

    public class ActiveDocument
    {
        public Guid Id { get; init; }
        public EDocumentType Type { get; init; }
        public DocumentRelation Relation { get; init; }
    }

    public class NewDocument
    {
        public Guid Id { get; init; }
        public EDocumentType Type { get; init; }
    }

    public record DocumentRelation
    {
        
    }

    public class TemporaryFile
    {
        
    }

    public enum EDocumentType
    {
        
    }

    public Example2(IRelatedDocumentsService relatedDocuments)
    {
        _relatedDocuments = relatedDocuments;
    }

    public async Task After()
    {
        await _relatedDocuments.AddNew(
            new DocumentRelation(),
            new NewDocument(),
            new TemporaryFile[] {});
    }
}