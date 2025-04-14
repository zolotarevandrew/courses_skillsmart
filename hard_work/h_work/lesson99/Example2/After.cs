namespace h_work.lesson99.Example2;

public interface ICommandHandler<in TParameter>
{
    Task HandleAsync(TParameter parameter);
}

public class DomainCommand {}
    
public class CreateStatementCommand : DomainCommand {}
public class CreateStatementCommandHandler : ICommandHandler<CreateStatementCommand>
{
    public Task HandleAsync(CreateStatementCommand parameter)
    {
        Console.WriteLine("create statement command");
        return Task.CompletedTask;
    }
}

public class ChangeStatementCrmIdCommand : DomainCommand {}
public class ChangeStatementCrmIdCommandHandler : ICommandHandler<ChangeStatementCrmIdCommand>
{
    public Task HandleAsync(ChangeStatementCrmIdCommand parameter)
    {
        Console.WriteLine("change crm id command");
        return Task.CompletedTask;
    }
}

public class CommandHandlerContrVarianceWrapper<T>(ICommandHandler<T> inner) : ICommandHandler<DomainCommand> where T : DomainCommand
{
    public Task HandleAsync(DomainCommand command)
    {
        if (command is not T typed)
        {
            throw new InvalidCastException($"Expected command of type {typeof(T).Name}, got {command.GetType().Name}");
        }
        
        return inner.HandleAsync(typed);
    }
}

public static IServiceCollection AddCommand<TCommand, THandler>(this IServiceCollection services)
    where TCommand : DomainCommand 
    where THandler : class, ICommandHandler<TCommand>
{
    services.AddScoped<ICommandHandler<TCommand>, THandler>();
    
    object serviceKey = typeof(TCommand);
    services.AddKeyedScoped<ICommandHandler<DomainCommand>>(serviceKey, (sp, key) =>
    {
        var inner = sp.GetRequiredService<ICommandHandler<TCommand>>();
        return new CommandHandlerContrVarianceWrapper<TCommand>(inner);
    });
    return services;
}

public abstract class CommandController(IServiceProvider sp) : ControllerBase
{
    protected Task HandleAsync<TCommand>(TCommand command)
        where TCommand : DomainCommand
    {
        var commandType = typeof(TCommand);
        var handler = sp.GetRequiredKeyedService<ICommandHandler<DomainCommand>>(commandType);
        return handler.HandleAsync(command);
    }
}