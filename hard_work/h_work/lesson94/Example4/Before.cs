namespace h_work.lesson94.Example4;

public class Before
{
    /*
     *  public async Task<EBankOnboardingStep?> Next(IBankOnboardingContext context, BankOnboardingStepInfo currentStep)
    {
        EBankOnboardingStep? result = await _dependencies.Logger.Log(
            context, _source, "IFlowMachineService.Next",
            async (data) =>
            {
                data["CurrentStep"] = new
                {
                    Step = currentStep.Step.ToString(),
                    currentStep.Sid,
                };

                var transitionContext = await GetContext(currentStep, context);
                var machine = _transitionPool.Get(transitionContext);
                EBankOnboardingStep? transition = await machine.GetStep(transitionContext);
                var result = await InternalNext(transition, context, currentStep);

                data["Result"] = result.ToString();

                return result;
            });

        if (result.HasValue && result == currentStep.Step && !result.Value.IsAllowSameStep())
        {
            var ex = new BankOnboardingException(context, "IFlowMachineService.Next error")
            {
                Data =
                {
                    ["CurrentStep"] = new
                    {
                        Step = currentStep.Step.ToString(),
                        currentStep.Sid,
                    },
                    ["Result"] = result.ToString()
                }
            };
            await _dependencies.Logger.Error(context, _source, "NextStepError", ex);

            result = null;
        }

        return result;
    }
     */
}