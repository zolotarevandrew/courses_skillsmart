namespace h_work.lesson80;

/*
public class OnboardingStepsCompletenessCalculator
{
    //после завершения хотя бы одного из этих шагов считаем, что пользователь всё завершил
    private static EBankOnboardingStep[] LastSteps = new[]
    {
        EBankOnboardingStep.PlanSelect,
        EBankOnboardingStep.UploadSupportingDocs,
        EBankOnboardingStep.JotForm
    };

    //если до этого шага дошёл - считаем, что пользователя можно отправлять на ревью
    private static EBankOnboardingStep[] ReadyForReviewSteps = new[]
    {
        EBankOnboardingStep.PlanSelect
    };
    
    public EFinomOnboardingStepCompletionStatus CalcStatus(IEnumerable<BankOnboardingStepFullInfo> actualSteps)
    {
        if (actualSteps.All(x => x.Status == EBankOnboardingStepStatus.Completed) && actualSteps.Any(c => c.Status == EBankOnboardingStepStatus.Completed && LastSteps.Contains(c.Step)))
            return EFinomOnboardingStepCompletionStatus.Completed;

        if (actualSteps.Any(x => ReadyForReviewSteps.Contains(x.Step)))
            return EFinomOnboardingStepCompletionStatus.ReadyForReview;

        return EFinomOnboardingStepCompletionStatus.InProgress;
    }
}
*/