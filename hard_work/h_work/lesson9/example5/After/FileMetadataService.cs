namespace h_work.lesson9.example5.After;

public interface IFileMetadataService
{
    Task<FileMetadata> Get(string filePath);
}
public class FileMetadataService : IFileMetadataService
{
    public Task<FileMetadata> Get(string filePath)
    {
        throw new NotImplementedException();
    }
}