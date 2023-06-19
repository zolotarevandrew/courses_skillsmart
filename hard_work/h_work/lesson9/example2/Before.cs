
using h_work.lesson9.example6;

namespace h_work.lesson9.example2;

public abstract class BaseFlowMachineTest
{
    protected abstract IFlowMachineService Machine();

    protected async Task<List<EBankOnboardingStep>> NextFlow(IBankOnboardingContext context, BankOnboardingStepInfo currentStep)
    {
        EBankOnboardingStep? nextStep = null;
        var res = new List<EBankOnboardingStep>();
        while (nextStep != EBankOnboardingStep.Dashboard)
        {
            nextStep = await Machine().Next(context, currentStep);
            if (nextStep == null) break;

            res.Add(nextStep.Value);
            currentStep = new BankOnboardingStepInfo
            {
                Step = nextStep.Value
            };
        }

        return res;
    }

    protected async Task<List<EBankOnboardingStep>> PrevFlow(IBankOnboardingContext context, BankOnboardingStepInfo currentStep)
    {
        EBankOnboardingStep? nextStep = null;
        var res = new List<EBankOnboardingStep>();
        while (nextStep != EBankOnboardingStep.Dashboard)
        {
            nextStep = await Machine().Previous(context, currentStep);
            if (nextStep == null) break;

            res.Add(nextStep.Value);
            currentStep = new BankOnboardingStepInfo
            {
                Step = nextStep.Value
            };
        }

        return res;
    }

}

public interface IFlowMachineService
{
    Task<EBankOnboardingStep?> Next(IBankOnboardingContext context, BankOnboardingStepInfo currentStep);
    Task<EBankOnboardingStep?> Previous(IBankOnboardingContext context, BankOnboardingStepInfo currentStep);
}

public class BankOnboardingStepInfo
{
    public EBankOnboardingStep Step { get; set; }
}