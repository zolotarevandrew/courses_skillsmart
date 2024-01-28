namespace h_work.lesson36;

public interface IBankOnboardingContext
{
    
}

public class BankOnboardingStepContext
{
    
}

public interface IExecuteStepServiceDependencies
{
    
}

public class BankOnboardingStepActionContext
{
    
}

public class BankOnboardingExecuteStepResult
{
    
}

//здесь только базовая логика выполнения и валидации шага
public abstract class BaseExecuteStepService
{
    private readonly IExecuteStepServiceDependencies _dependencies;
    private readonly string _source;

    protected BankOnboardingStepActionContext ActionContext { get; private set; }

    protected BaseExecuteStepService(IExecuteStepServiceDependencies dependencies)
    {
        _dependencies = dependencies;
        _source = GetType().Name;
    }

    protected virtual Task<BankOnboardingExecuteStepResult> Execute<T>(
        IBankOnboardingContext context,
        BankOnboardingStepContext stepContext, T contract)
    {
        return Task.FromResult(new BankOnboardingExecuteStepResult { });
    }

    protected virtual Task ValidateContract<T>(
        IBankOnboardingContext context,
        BankOnboardingStepContext stepContext, T contract)
    {
        return Task.CompletedTask;
    }
}

//даем возможность реализовать возможность пропуска шага, (нужно редко и не на всех шагах)
public interface IWithSkipStepService
{
    public Task<bool> SkipExecute(IBankOnboardingContext context, BankOnboardingStepContext stepContext)
    {
        //default implementation in here
        return Task.FromResult(true);
    }
}

//даем возможность переопределить следующий шаг
public interface IWithCustomNextStepService
{
    public Task NextStepDefined(
        IBankOnboardingContext context,
        BankOnboardingStepContext stepContext,
        BankOnboardingStepContext nextStepContext)
    {
        //default implementation in here
        return Task.CompletedTask;
    }
}

public class MyCustomStepService : BaseExecuteStepService, IWithSkipStepService, IWithCustomNextStepService
{
    public MyCustomStepService(IExecuteStepServiceDependencies dependencies) : base(dependencies)
    {
    }
}