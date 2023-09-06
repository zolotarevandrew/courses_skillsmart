namespace h_work.lesson20.example2;

public class CompanyLoadedDocumentResult
{
    public LoadedDocumentStatus Status { get; set; }
    public Guid? PendingDocId { get; set; }
    public Guid? DocId { get; set; }
    public string ErrorMessage { get; set; }
}

public enum LoadedDocumentStatus
{
    Error = 1,
    Pending = 2,
    Success = 3
}

public class LoadCompanyDocumentRequest
{

}

public class ExternalResponse
{
    public bool IsSuccess { get; set; }
    public bool IsPending { get; set; }
    public ExternalResponseBody Body { get; set; }
}

public class ExternalResponseBody
{
    public bool IsError { get; set; }
    public Guid? PendingDocumentId { get; set; }
    public Guid? DocumentId { get; set; }
}

public class Before
{
    public async Task<CompanyLoadedDocumentResult> GetAsync(LoadCompanyDocumentRequest request, CancellationToken cancellationToken = default)
    {
        ExternalResponse response = await LoadExternalDocument(request);

        var res = new CompanyLoadedDocumentResult();
        if (!response.IsSuccess)
        {
            res.Status = LoadedDocumentStatus.Error;
            res.ErrorMessage = "some message";
            return res;
        }

        if (response.Body?.IsError == true)
        {
            res.Status = LoadedDocumentStatus.Error;
            res.ErrorMessage = "some other message";
            return res;
        }

        if (response.IsPending)
        {
            res.Status = LoadedDocumentStatus.Pending;
            res.PendingDocId = response.Body.DocumentId;
            return res;
        }

        res.Status = LoadedDocumentStatus.Success;
        res.DocId = response.Body.DocumentId;
        return res;
    }

    private static async Task<ExternalResponse> LoadExternalDocument(LoadCompanyDocumentRequest request)
    {
        throw new NotImplementedException();
    }
}