using h_work.lesson9.example6;

namespace h_work.lesson11.example2;

public interface IOnboardingCompletnessService
{
    Task<OnboardingCompletness> Get(IBankOnboardingContext context);
}

public class OnboardingCompletness
{
    public EFinomOnboardingCompletionStatus Status { get; }
    public bool IsCompleted => Status == EFinomOnboardingCompletionStatus.Completed;

    public OnboardingCompletness(EFinomOnboardingCompletionStatus status)
    {
        Status = status;
    }
}

public enum EFinomOnboardingCompletionStatus
{
    InProgress = 1,
    Completed = 2
}

