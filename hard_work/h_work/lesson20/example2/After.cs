namespace h_work.lesson20.example2;

public abstract record CompanyLoadedDocument
{

}

public record SuccessCompanyLoadedDocument(Guid DocumentId) : CompanyLoadedDocument;
public record ErrorCompanyLoadedDocument(string Message) : CompanyLoadedDocument;
public record PendingCompanyLoadedDocument(Guid PendingDocumentId) : CompanyLoadedDocument;

public class After
{
    public async Task<CompanyLoadedDocument> GetAsync(LoadCompanyDocumentRequest request, CancellationToken cancellationToken = default)
    {
        ExternalResponse response = await LoadExternalDocument(request);

        if (!response.IsSuccess) return new ErrorCompanyLoadedDocument("some message");
        if (response.Body?.IsError == true) return new ErrorCompanyLoadedDocument("some other message");
        if (response.IsPending) return new PendingCompanyLoadedDocument(response.Body.PendingDocumentId.Value);

        return new SuccessCompanyLoadedDocument(response.Body.DocumentId.Value);
    }

    private static async Task<ExternalResponse> LoadExternalDocument(LoadCompanyDocumentRequest request)
    {
        throw new NotImplementedException();
    }
}