

namespace h_work.lesson9.example5
{
    public class DocumentsHelper
    {
        private readonly IDocumentsStorageService _documentsStorageService;
        private readonly IDocumentsService _documentsService;

        public DocumentsHelper(IDocumentsService documentsService, IDocumentsStorageService documentsStorageService)
        {
            _documentsService = documentsService;
            _documentsStorageService = documentsStorageService;
        }

        public async Task StoreFile(Guid documentId, Guid entityId, string originDocType,
            EDocumentType documentType, Stream fileStream, string fileName,
            string mimetype, int? fileSize, Guid? author = null)
        {
            string filePathResult = await _documentsService.StoreFile(entityId, documentId,
                originDocType ?? documentType.ToString(), fileStream, mimetype);

            var entity = new DocumentStorageEntity
            {
                Author = author,
                CreatedAt = DateTime.UtcNow,
                DocumentType = documentType,
                EntityId = entityId,
                FileName = fileName ?? string.Empty,
                Mimetype = mimetype,
                FileSize = fileSize,
                FilePath = filePathResult,
                Id = documentId
            };

            await _documentsStorageService.Insert(entity);
        }

        public async Task StoreFile(DocumentInfo documentInfo)
        {
            await _documentsStorageService.Insert(new DocumentStorageEntity
            {
                Author = documentInfo.Author,
                CreatedAt = DateTime.UtcNow,
                DocumentType = documentInfo.DocumentType,
                EntityId = documentInfo.EntityId,
                FileName = documentInfo.FileName,
                Mimetype = documentInfo.Mimetype,
                FilePath = documentInfo.FilePath,
                Id = documentInfo.Id
            });
        }

        public async Task<Guid> StoreFile(Guid entityId, string filePath,
            EDocumentType documentType, string fileName = null,
            Guid? author = null, Guid? sid = null, bool autoUpload = false, Guid? fileId = null)
        {
            FileMetadata fileMetadata = await GetMetadata(filePath);

            if(fileId == Guid.Empty)
            {
                fileId = null;
            }

            fileId ??= Guid.NewGuid();
            string filePathResult = await _documentsService.StoreFile(entityId, fileId.Value,
                documentType.ToString(), filePath);

            await _documentsStorageService.Insert(new DocumentStorageEntity
            {
                Author = author,
                CreatedAt = DateTime.UtcNow,
                DocumentType = documentType,
                EntityId = entityId,
                FileName = fileName ?? string.Empty,
                Mimetype = fileMetadata?.Mimetype,
                FileSize = (int?)fileMetadata?.Size,
                FilePath = filePathResult,
                Id = fileId.Value,
                StepSid = sid,
                AutoUpload = autoUpload,
            });

            return fileId.Value;
        }

        private async Task<FileMetadata> GetMetadata(string filePath)
        {
            throw new NotImplementedException();
        }
    }

    public interface IDocumentsService
    {
        Task<string> StoreFile(Guid entityId, Guid fileId, string documentType, string filePath);
        Task<string> StoreFile(Guid entityId, Guid fileId, string documentType, Stream stream, string mimeType);
        Task<object> GetFileInfoByFullPath(string s);
        Task<object> GetFileInfo(string filePath);
    }

    public interface IDocumentsStorageService
    {
        Task Insert(DocumentStorageEntity documentStorageEntity);
    }

    public class DocumentInfo
    {
        public Guid EntityId { get; set; }
        public string FileName { get; set; }
        public object DocumentType { get; set; }
        public Guid Id { get; set; }
        public object Mimetype { get; set; }
        public string FilePath { get; set; }
        public Guid? Author { get; set; }
    }

    public class FileMetadata
    {
        public object Mimetype { get; set; }
        public int? Size { get; set; }
    }

    public enum EDocumentType
    {
    }

    public class DocumentStorageEntity
    {
        public Guid? Author { get; set; }
        public DateTime CreatedAt { get; set; }
        public object DocumentType { get; set; }
        public Guid EntityId { get; set; }
        public string FileName { get; set; }
        public object Mimetype { get; set; }
        public int? FileSize { get; set; }
        public string FilePath { get; set; }
        public Guid Id { get; set; }
        public object Status { get; set; }
        public Guid? StepSid { get; set; }
        public bool AutoUpload { get; set; }
    }
}
