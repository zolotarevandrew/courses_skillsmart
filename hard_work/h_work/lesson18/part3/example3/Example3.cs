namespace h_work.lesson18.part3.example3;

//Before
public interface IBankOnboardingContext
{
    Guid CompanyId { get; set; }
    Guid UserId { get; set; }
}

public record TaxIdentificationReminderStatus();

public class FileInfoContract
{

}
public interface ITaxIdentificationService
{
    Task<FinomTaxIdentificationStatus> GetStatus(IBankOnboardingContext onboarding);

    Task<TaxIdentificationReminderStatus> GetReminderStatus(IBankOnboardingContext onboarding);

    Task StartByOnboarding(IBankOnboardingContext onboarding);

    Task RunReminder(IBankOnboardingContext onboarding, int remindNumber);
    Task TryRemind(IBankOnboardingContext onboarding, int remindNumber);
    Task WaitAnotherTaxInfo(IBankOnboardingContext onboarding);

    Task ProvideByUser(IBankOnboardingContext onboarding, string taxNumber, FileInfoContract document);
    Task SaveProvidedTaxInfo(IBankOnboardingContext onboarding, string taxNumber, FileInfoContract document);

    Task UpdateReminderStatus(IBankOnboardingContext onboarding);
}


//After
public record FinomTaxIdentificationContext(Guid CompanyId, Guid UserId);
public record FinomTaxIdentificationStatus(string Status);
public record ProvidedByUserTaxInfo(string TaxNumber, string DocId);

public interface IFinomTaxIdentificationServiceV2
{
    Task Start(FinomTaxIdentificationContext context);
    Task<FinomTaxIdentificationStatus> GetStatus(FinomTaxIdentificationContext context);

    Task TryRemind(FinomTaxIdentificationContext context, int remindNumber);

    Task ExceedDeadline(FinomTaxIdentificationContext context);
    Task ReRequest(FinomTaxIdentificationContext context);
    Task MoveForCheck(FinomTaxIdentificationContext context);

    Task ProvideByUser(FinomTaxIdentificationContext context, ProvidedByUserTaxInfo taxInfo);

    Task ForceComplete(FinomTaxIdentificationContext context);
    Task Complete(FinomTaxIdentificationContext context, ProvidedByUserTaxInfo taxInfo);
    Task MoveToBlock(FinomTaxIdentificationContext context);
}