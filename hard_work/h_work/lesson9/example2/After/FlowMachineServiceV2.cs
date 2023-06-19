using h_work.lesson9.example6;

namespace h_work.lesson9.example2.After;


public interface IFlowMachineService
{
    IAsyncEnumerable<EBankOnboardingStep?> NextEnumerable(IBankOnboardingContext context, BankOnboardingStepInfo currentStep);
    IAsyncEnumerable<EBankOnboardingStep?> PrevEnumerable(IBankOnboardingContext context, BankOnboardingStepInfo currentStep);
}

public static class StepEnumerableExtensions
{
    public static async Task<EBankOnboardingStep?> Current(this IAsyncEnumerable<EBankOnboardingStep?> enumerable)
    {
        await using var enumerator = enumerable.GetAsyncEnumerator();
        var first = await enumerator.MoveNextAsync() ? enumerator.Current : default;
        return first;
    }
}

public class FlowMachineServiceV2 : IFlowMachineService
{
    public async IAsyncEnumerable<EBankOnboardingStep?> NextEnumerable(IBankOnboardingContext context, BankOnboardingStepInfo currentStep)
    {
        EBankOnboardingStep? nextStep = null;
        while (nextStep != EBankOnboardingStep.Dashboard)
        {
            nextStep = await Next(context, currentStep);
            if (nextStep == null) yield break;

            yield return nextStep;
            
            currentStep = new BankOnboardingStepInfo
            {
                Step = nextStep.Value
            };
        }
    }

    public async IAsyncEnumerable<EBankOnboardingStep?> PrevEnumerable(IBankOnboardingContext context, BankOnboardingStepInfo currentStep)
    {
        EBankOnboardingStep? prevStep = null;
        while (prevStep != EBankOnboardingStep.Dashboard)
        {
            prevStep = await Previous(context, currentStep);
            if (prevStep == null) yield break;

            yield return prevStep;
            
            currentStep = new BankOnboardingStepInfo
            {
                Step = prevStep.Value
            };
        }
    }

    async Task<EBankOnboardingStep?> Next(IBankOnboardingContext context, BankOnboardingStepInfo currentStep)
    {
        if (currentStep.Step == EBankOnboardingStep.RegistratorVerification)
            return EBankOnboardingStep.NonRegistratorVerification;
        return null;
    }

    async Task<EBankOnboardingStep?> Previous(IBankOnboardingContext context, BankOnboardingStepInfo currentStep)
    {
        return EBankOnboardingStep.NonRegistratorVerification;
    }
}