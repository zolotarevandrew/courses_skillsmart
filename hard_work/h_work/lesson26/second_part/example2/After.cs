using h_work.lesson9.example5;

namespace h_work.lesson26.second_part.example2
{
    public interface IRelatedDocumentsServiceV2
    {
        Task<ActiveDocumentsGroup> GetActive(
            DocumentRelation relation,
            params EDocumentType[] documentTypes);
    }
    
    public class ActiveDocument
    {
        public Guid Id { get; init; }
        public EDocumentType Type { get; init; }
        public DateTime Created { get; init; }
        public List<DocumentFile> Files { get; init; } = new();
    }
    
    public class ActiveDocumentsGroup 
    {
        public DocumentRelation Relation { get; }
        private readonly List<ActiveDocument> _documents;

        public ActiveDocumentsGroup(DocumentRelation relation, IEnumerable<ActiveDocument> documents)
        {
            Relation = relation;
            _documents = documents
                .OrderByDescending( d => d.Created)
                .ToList();
        }

        public ActiveDocument? LastOrDefault(EDocumentType documentType)
        {
            return _documents.FirstOrDefault(x => x.Type == documentType);
        }

        public List<ActiveDocument> AllByType(EDocumentType documentType)
        {
            return _documents.Where( x => x.Type == documentType).ToList();
        }
    }
}

