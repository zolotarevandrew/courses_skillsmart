using h_work.lessson10.example2;

namespace h_work.lesson94.Example5;

public interface IBankOnboardingContextService
{
    Task<IBankOnboardingContext> GetExistingById(Guid onboardingId);
}

public interface IAdvancedDataCollectionService
{
    Task UpdateDowngradeTimings(IBankOnboardingContext context);
}

public class ForceAccountDowngradeExternalTask(
    IBankOnboardingContextService bankOnboardingContextService,
    IAdvancedDataCollectionService advancedDataCollectionService
) : IExternalTaskHandler
{
    public async Task<IExecutionResult> HandleAsync(ExternalTask externalTask, CancellationToken cancellationToken)
    {
        Guid onboardingId = externalTask.GetRequiredGuidProperty(VariableNames.CustomEntityId);
        var onboardingContext = await bankOnboardingContextService.GetExistingById(onboardingId);
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