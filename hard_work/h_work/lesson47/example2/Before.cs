namespace h_work.lesson47.example2;

public enum EOnboardingCompletionPoint
{
    Steps,
    DocumentSigning
}

public enum EOnboardingStepCompletionStatus
{
    InProgress = 1,
    UserFlowCompleted = 2,
    Completed = 2
}

public enum EOnboardingDocumentSigningStatus
{
    None = 0,
    Created  = 1,
    Completed = 2
}

public class OnboardingDocumentSigningStatus
{
    public bool Available { get; init; }
    public EOnboardingDocumentSigningStatus Status { get; init; }
}

public class OnboardingCompletness
{
    private Dictionary<EOnboardingCompletionPoint, bool> _completedByPoints;

    //TBD make this better ATD next time (rethink IsUserFlowCompleted);
    private readonly EOnboardingStepCompletionStatus _stepCompletionStatus;
    private readonly OnboardingDocumentSigningStatus _documentSigning;

    public bool IsCompleted => _completedByPoints.All( c => c.Value == true);
    public bool IsUserFlowCompleted => _stepCompletionStatus != EOnboardingStepCompletionStatus.InProgress;

    public OnboardingCompletness(
        EOnboardingStepCompletionStatus stepCompletionStatus,
        OnboardingDocumentSigningStatus documentSigning)
    {
        _stepCompletionStatus = stepCompletionStatus;
        _documentSigning = documentSigning;

        _completedByPoints = new Dictionary<EOnboardingCompletionPoint, bool>
        {
            { EOnboardingCompletionPoint.Steps, stepCompletionStatus == EOnboardingStepCompletionStatus.Completed }
        };
        if (documentSigning.Available)
        {
            _completedByPoints[EOnboardingCompletionPoint.DocumentSigning] = documentSigning.Status == EOnboardingDocumentSigningStatus.Completed;
        }
    }

    public bool CheckCompleted(EOnboardingCompletionPoint point)
    {
        if (!_completedByPoints.ContainsKey(point)) return false;

        return _completedByPoints[point] == true;
    }
}