
/*

public abstract class CompanyLoadedDocumentResult
{
    public abstract EDocumentStatusType Status { get; }
}

public class PendingCompanyLoadedDocumentResult : CompanyLoadedDocumentResult
{
    public DocumentStatus Pending { get; init; }
    public override EDocumentStatusType Status => EDocumentStatusType.Pending;
}

public class FailedCompanyLoadedDocumentResult : CompanyLoadedDocumentResult
{
    public override EDocumentStatusType Status => EDocumentStatusType.Error;
    public bool CanRetry { get; init; }
}

public class SuccessCompanyLoadedDocumentResult : CompanyLoadedDocumentResult
{
    public DocumentStatus Success { get; init; }
    public CompanyLoadedDocument Document { get; init; }
    public override EDocumentStatusType Status => EDocumentStatusType.Success;
}


  public async Task LoadAsync(LoadCompanyDocumentRequest request)
    {
        var loadDocumentResult = await _documentGetter.GetAsync(request);

        var status = loadDocumentResult.Status;
        var processTask = status switch
                          {
                              EDocumentStatusType.Success => ProcessSuccess(request, loadDocumentResult as SuccessCompanyLoadedDocumentResult),
                              EDocumentStatusType.Pending => ProcessPending(request, loadDocumentResult as PendingCompanyLoadedDocumentResult),
                              EDocumentStatusType.Error => ProcessError(request, loadDocumentResult as FailedCompanyLoadedDocumentResult),
                              _ => throw new NotSupportedException(),
                          };

        await processTask;
    }


*/