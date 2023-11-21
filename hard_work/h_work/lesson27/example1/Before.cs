using System.Runtime.CompilerServices;

namespace h_work.lesson27.example1;

public interface IBankOnboardingContext
{
    
}
public interface IPersonVerificationService
{
    Task Create(IBankOnboardingContext context, FinomCreatePersonVerification request, [CallerMemberName] string source = "");
    Task SetInProgress(IBankOnboardingContext context, FinomStartPersonVerification request, [CallerMemberName] string source = "");
    Task SetFailed(IBankOnboardingContext context, FinomFailedPersonVerification request, [CallerMemberName] string source = "");
    Task SetSuccess(IBankOnboardingContext context, FinomSuccessPersonVerification request, [CallerMemberName] string source = "");
    Task SetPending(IBankOnboardingContext context, FinomPersonVerificationPending request, [CallerMemberName] string source = "");

    Task<FinomPersonVerificationGroup> GetAll(IBankOnboardingContext context);
    Task<FinomPersonVerification> GetById(IBankOnboardingContext context, Guid personId);
}

public enum EPersonVerificationState
{
    Created,
    InProgress,
    Pending,
    Failed,
    Repeat,
    Success,
}

public class FinomPersonVerificationPending
{
}

public class FinomSuccessPersonVerification
{
}

public class FinomFailedPersonVerification
{
}

public class FinomStartPersonVerification
{
}

public class FinomCreatePersonVerification
{
    public Guid PersonId { get; set; }
}

public class FinomPersonVerification
{
}

public class FinomPersonVerificationGroup
{
}