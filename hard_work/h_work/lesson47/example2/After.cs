namespace h_work.lesson47.example2;


public enum EOnboardingCompletionPointV2
{
    UserFlow = 1,
    Pricing = 2,
    DocumentSigning = 3,
    All = 4
}

public interface IOnboardingCompletionPointV2
{
    EOnboardingCompletionPointV2 Type { get; }
    bool Completed { get; }
}

public interface IOnboardingOptionalCompletionPointV2 : IOnboardingCompletionPointV2
{
    bool Required { get; }
}

public class UserFlowOnboardingCompletionPoint : IOnboardingCompletionPointV2
{
    public EOnboardingCompletionPointV2 Type => EOnboardingCompletionPointV2.UserFlow;
    public bool Completed { get; }

    public UserFlowOnboardingCompletionPoint(EOnboardingStepCompletionStatus status)
    {
        Completed = status == EOnboardingStepCompletionStatus.UserFlowCompleted;
    }
}

public class PricingOnboardingCompletionPoint : IOnboardingCompletionPointV2
{
    public EOnboardingCompletionPointV2 Type => EOnboardingCompletionPointV2.Pricing;
    public bool Completed { get; }

    public PricingOnboardingCompletionPoint(bool completed)
    {
        Completed = completed;
    }
}

public class DocumentSigningCompletionPoint : IOnboardingOptionalCompletionPointV2
{
    public EOnboardingCompletionPointV2 Type => EOnboardingCompletionPointV2.DocumentSigning;
    public bool Completed { get; }
    public bool Required { get; }

    public DocumentSigningCompletionPoint(OnboardingDocumentSigningStatus status)
    {
        Completed = status.Status == EOnboardingDocumentSigningStatus.Completed;
        Required = status.Available;
    }
}

public delegate Task OnboardingPointCompletionDelegate();

public class OnboardingCompletnessV2
{
    private Dictionary<EOnboardingCompletionPointV2, bool> _completedByPoints;
    
    //здесь есть обязательные поинты, явно передаем их в конструктор, опциональные передаем доп.списком
    public OnboardingCompletnessV2(
        UserFlowOnboardingCompletionPoint userFlowCompletionPoint,
        PricingOnboardingCompletionPoint pricingCompletionPoint,
        params IOnboardingOptionalCompletionPointV2[] optionalPoints
        )
    {
        var allPoints = new IOnboardingCompletionPointV2[]
            {
                userFlowCompletionPoint,
                pricingCompletionPoint
            }
            .Concat(optionalPoints.Where(p => p.Required));
        
        _completedByPoints = allPoints
            .ToDictionary(c => c.Type, c => c.Completed);
        
        //Дополнительно высчитываем All
        _completedByPoints[EOnboardingCompletionPointV2.All] = _completedByPoints.All(c => c.Value);
    }
    
    //добавляем возможность выполнения функции если поинт завершен
    public Task CheckCompleted(EOnboardingCompletionPointV2 point, OnboardingPointCompletionDelegate completion)
    {
        _completedByPoints.TryGetValue(point, out var completedStatus);
        var completionHandler = completedStatus ? completion : NotCompletedPoint;
        return completionHandler();
    }

    static Task NotCompletedPoint()
    {
        return Task.CompletedTask;
    }
}