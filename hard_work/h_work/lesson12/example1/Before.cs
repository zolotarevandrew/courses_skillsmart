using h_work.lesson9.example6;

namespace h_work.lesson12.example1;


public class AllStepsCompletedRequest
{
    public string TariffId { get; set; }
    public bool IsAnnual { get; set; }
}

public interface IMissingInformationProcessNotifier
{
    Task<bool> Notify(IBankOnboardingContext context);
}

public interface IOpeningAccountProcessService : IMissingInformationProcessNotifier
{
    Task Start(IBankOnboardingContext context);
    Task<bool> UserCheckedLr(IBankOnboardingContext context);
    Task<bool> UserSelectedHimself(IBankOnboardingContext context);
    Task<bool> PersonsVerificationsCompleted(IBankOnboardingContext context);
    Task<bool> AllStepsCompleted(IBankOnboardingContext context, AllStepsCompletedRequest request);
}