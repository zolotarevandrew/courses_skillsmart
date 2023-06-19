namespace h_work.lesson9.example5.After;

public class OnboardingDocument
{
    public Guid EntityId { get; init; }
    public string FileName { get; init; }
    public string DocumentType { get; init; }
    public Guid Id { get; init; }
    public string Mimetype { get; init; }
    public string FilePath { get; init; }
    public int FileSize { get; init; }
    public Guid Author { get; set; }
}

public interface IOnboardingDocumentStore
{
    Task Store(OnboardingDocument document);
}
public class OnboardingDocumentStore : IOnboardingDocumentStore
{
    private readonly IBlobStore _blobStore;
    private readonly IDocumentsStorageService _documentsStorageService;

    public OnboardingDocumentStore(IBlobStore blobStore, IDocumentsStorageService documentsStorageService)
    {
        _blobStore = blobStore;
        _documentsStorageService = documentsStorageService;
    }
    public async Task Store(OnboardingDocument document)
    {
        using MemoryStream ms = new MemoryStream();
        await using FileStream file = new FileStream(document.FilePath, FileMode.Open, FileAccess.Read);
        await file.CopyToAsync(ms);
        
        var blob = new Blob(document.EntityId, document.Id, document.DocumentType, ms, document.Mimetype);
        var savedBlob = await _blobStore.Store(blob);

        var entity = new DocumentStorageEntity
        {
            Author = document.Author,
            CreatedAt = DateTime.UtcNow,
            DocumentType = document.DocumentType,
            EntityId = document.EntityId,
            FileName = document.FileName,
            Mimetype = document.Mimetype,
            FileSize = document.FileSize,
            FilePath = savedBlob.FilePath,
            Id = document.Id
        };

        await _documentsStorageService.Insert(entity);
    }
}