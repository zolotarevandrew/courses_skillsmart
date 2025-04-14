namespace h_work.lesson99.Example3;

public class QueryController<TQuery>(IServiceProvider provider) : ControllerBase
        where TQuery : IQuery<QueryResult>
{
    protected Task<QueryResult> Get(TQuery query)
    {
        var handler = provider.GetRequiredKeyedService<IQueryHandler<IQuery<QueryResult>, QueryResult>>(query.GetType());
        return handler.QueryAsync(query);
    }
}

public abstract class QueryResult {}
public class UserByIdResult : QueryResult {}

public interface IQuery<out TResult> where TResult : QueryResult { } 
public class GetUserByIdQuery : IQuery<UserByIdResult> { }

public interface IQueryHandler<in TQuery, TResult>
    where TQuery : IQuery<TResult>
    where TResult : QueryResult
{
    Task<TResult> QueryAsync(TQuery query);
}

public class GetUserByIdQueryHandler : IQueryHandler<GetUserByIdQuery, UserByIdResult>
{
    public Task<UserByIdResult> QueryAsync(GetUserByIdQuery query)
    {
        Console.WriteLine("GetUserByIdQueryHandler");
        return Task.FromResult(new UserByIdResult());
    }
}

public class QueryHandlerWrapper<TQuery, TResult>(IQueryHandler<TQuery, TResult> _inner) : IQueryHandler<IQuery<QueryResult>, QueryResult>
    where TQuery : IQuery<TResult>
    where TResult : QueryResult
{
    public async Task<QueryResult> QueryAsync(IQuery<QueryResult> query)
    {
        var res = await _inner.QueryAsync((TQuery)query);
        return res;
    }
}

public static IServiceCollection AddHandler<TQuery, TResult, TQueryHandler>(this IServiceCollection services)
    where TQuery : IQuery<TResult> 
    where TResult : QueryResult
    where TQueryHandler : class, IQueryHandler<TQuery, TResult>
{
    services.AddScoped<IQueryHandler<TQuery, TResult>, TQueryHandler>();

    object serviceKey = typeof(TQuery);
    services.AddKeyedScoped<IQueryHandler<IQuery<QueryResult>, QueryResult>>(serviceKey, (sp, key) =>
    {
        var inner = sp.GetRequiredService<IQueryHandler<TQuery, TResult>>();
        return new QueryHandlerWrapper<TQuery, TResult>(inner);
    });
    return services;
}