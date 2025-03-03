namespace h_work.lesson94.Example5;

/*
 * public class ForceAccountDowngradeExternalTask(
    IBankOnboardingContextService bankOnboardingContextService,
    IAdvancedDataCollectionService advancedDataCollectionService
    ) : IExternalTaskHandler
{
    public async Task<IExecutionResult> HandleAsync(ExternalTask externalTask, CancellationToken cancellationToken)
    {
        Guid? onboardingId = externalTask.GetGuidProperty(VariableNames.CustomEntityId);
        if (!onboardingId.HasValue) throw new Exception("Custom entity id is not defined");

        var onboardingContext = await bankOnboardingContextService.GetById(onboardingId.Value);
        if (onboardingContext is null) throw new Exception($"Onboarding '{onboardingId}' doesn't exist");

        var downgradeTimings = await advancedDataCollectionService.UpdateDowngradeTimings(onboardingContext, immediateClosure: true);

        return new CompleteResult
        {
            AddVariables = new Dictionary<string, object>
            {
                [ProcessVariables.DowngradeTimings] = downgradeTimings
            }
        };
    }
}
*/