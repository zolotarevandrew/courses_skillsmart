namespace h_work.lesson9.example5.After;

public record Blob(Guid EntityId, Guid FileId, string Type, Stream Stream, string MimeType);
public record SavedBlob(string FilePath);

public interface IBlobStore
{
    Task<SavedBlob> Store(Blob blob);
}