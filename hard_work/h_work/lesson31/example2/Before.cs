namespace h_work.lesson31.example2;

public interface IComplexQuestionnaireService
{
    Task SetData(Guid companyId, ComplexQuestionnaireData data);
    Task<ComplexQuestionnaireData> GetData(Guid companyId);
    Task SubmitActivity(Guid companyId, Guid userId);
    Task<bool> IsActivitySubmitted(Guid companyId);
    Task SubmitPaymentInformation(Guid companyId, Guid userId);
    Task<bool> IsPaymentInformationSubmitted(Guid companyId);
}

public class ComplexQuestionnaireData
{
}