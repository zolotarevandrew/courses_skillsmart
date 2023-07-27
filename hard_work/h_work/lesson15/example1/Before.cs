namespace h_work.lesson15.example1;

public interface ITestBankOnboardingContext
{
    Guid PersonId { get; }
}

public interface IPersonFlowMachineService : IFlowMachineService
{

}

public interface IFlowMachineService
{

}

public interface IFlowMachineServiceFactory
{
    Task<IFlowMachineService> GetPersonsService(ITestBankOnboardingContext context, Guid contextPersonId);
}

public class Before
{
    private IFlowMachineServiceFactory _flowMachineServiceFactory;
    public Before(IFlowMachineServiceFactory flowMachineServiceFactory)
    {
        _flowMachineServiceFactory = flowMachineServiceFactory;
    }

    public async Task Test()
    {
        ITestBankOnboardingContext context = null;

        var flowMachine = await _flowMachineServiceFactory.GetPersonsService(context, context.PersonId) as IPersonFlowMachineService;
        if (flowMachine == null)
            throw new OnboardingInconsistentStateException(context, "Temp access flow machine was not found!");
    }
}

public class OnboardingInconsistentStateException : Exception
{
    public OnboardingInconsistentStateException(ITestBankOnboardingContext context, string tempAccessFlowMachineWasNotFound)
    {
        throw new NotImplementedException();
    }
}