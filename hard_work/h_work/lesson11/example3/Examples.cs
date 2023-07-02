using h_work.lesson9.example5;

namespace h_work.lesson11.example3;

public interface IFilesService
{
    Task<FileMetadata> GetMetadata(string filePath);
    Task<FileMetadata> GetDossierFileMetadata(string filePath);
}

public class FilesService : IFilesService
{
    private readonly IDocumentsService _documentsService;

    public FilesService(IDocumentsService documentsService)
    {
        _documentsService = documentsService;
    }

    public async Task<FileMetadata> GetDossierFileMetadata(string filePath)
    {
        var fileInfo = await _documentsService.GetFileInfoByFullPath($"dossier/{filePath}");
        return await СonvertMetadata(filePath, fileInfo);
    }

    public async Task<FileMetadata> GetMetadata(string filePath)
    {
        var fileInfo = await _documentsService.GetFileInfo(filePath);
        return await СonvertMetadata(filePath, fileInfo);
    }
    
    private async Task<FileMetadata> СonvertMetadata(string filePath, object fileInfo)
    {
        throw new NotImplementedException();
    }
}