using h_work.lesson18.part3.example3;

namespace h_work.lesson27.example2;

public interface ITaxIdentificationService
{
    Task<FinomTaxIdentificationStatus> GetStatus(FinomTaxIdentificationContext context);
    
    Task Start(FinomTaxIdentificationContext context);
    
    Task ExceedDeadline(FinomTaxIdentificationContext context);
    Task ReRequest(FinomTaxIdentificationContext context);
    Task MoveForCheck(FinomTaxIdentificationContext context);
    
    Task Complete(FinomTaxIdentificationContext context, ProvidedByUserTaxInfo taxInfo);
    
    Task MoveToBlock(FinomTaxIdentificationContext context);
}