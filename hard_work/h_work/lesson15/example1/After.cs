namespace h_work.lesson15.example1;



public interface IFlowMachineServiceFactoryV2
{
    Task<IPersonFlowMachineService> GetPersonsService(ITestBankOnboardingContext context, Guid contextPersonId);
}

public class After
{
    private IFlowMachineServiceFactoryV2 _flowMachineServiceFactory;
    public After(IFlowMachineServiceFactoryV2 flowMachineServiceFactory)
    {
        _flowMachineServiceFactory = flowMachineServiceFactory;
    }

    public async Task Test()
    {
        ITestBankOnboardingContext context = null;

        var flowMachine = await _flowMachineServiceFactory.GetPersonsService(context, context.PersonId);
    }
}
