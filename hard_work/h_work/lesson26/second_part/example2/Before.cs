using h_work.lesson9.example5;

namespace h_work.lesson26.second_part.example2;

public interface IRelatedDocumentsService
{
    Task<List<Document>> GetActive(
        DocumentRelation relation,
        params EDocumentType[] documentTypes);
}

public record DocumentRelation(Guid Id, EDocumentRelationType Type)
{
    public static DocumentRelation Person(Guid personId) =>
        new(personId, EDocumentRelationType.Person);

    public static DocumentRelation Company(Guid companyId) =>
        new(companyId, EDocumentRelationType.Company);
}

public enum EDocumentRelationType
{
    Person,
    Company
}

public class Document
{
    public Guid Id { get; init; }
    public EDocumentType Type { get; init; }
    public DateTime Created { get; init; }
    public List<DocumentFile> Files { get; init; } = new();
}

public class DocumentFile
{
    public string Name { get; init; }
    public string Path { get; init; }
    public DocumentFileMetadata Metadata { get; init; }
}

public record DocumentFileMetadata(string ContentType, int? Size);