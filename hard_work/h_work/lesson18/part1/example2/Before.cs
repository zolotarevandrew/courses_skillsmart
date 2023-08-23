namespace h_work.lesson18.part1.example2;

public class BankOnboardingStep
{
    public Step Step { get; set; }
}

public enum Step
{
    Ident = 1,
}

public interface IBankOnboardingContext
{
    OnboardingStatus Status { get; set; }
}

public enum OnboardingStatus
{
    Completed = 1
}

public interface IStepSummaryStatus
{
    Task<(bool, bool)> SummaryStatus(IBankOnboardingContext context);
}

public class StateMachine
{
    private readonly IStepSummaryStatus _status;
    public StateMachine(IStepSummaryStatus status)
    {
        _status = status;
    }

    protected async Task<BankOnboardingStep> GetNextForCompleted(IBankOnboardingContext context, BankOnboardingStep currentStep)
    {
        bool isIdentStep = currentStep.Step == Step.Ident;

        // Если побывал на всех обязательных шагах онбординга,
        // то отправляем на дашборд - пусть там гуляет.
        var (allStepsVisited, allStepsCompleted) = await _status.SummaryStatus(context);
        bool notAllowedCompleteStep = context.Status == OnboardingStatus.Completed;

        if (!isIdentStep && allStepsVisited && allStepsCompleted
            && notAllowedCompleteStep)
        {
            //dashboard
            return null;
        }

        //..hidden
        return null;
    }
}