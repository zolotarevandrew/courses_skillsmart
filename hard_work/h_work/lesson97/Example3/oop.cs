namespace h_work.lesson97.Example3;


public interface IGetQuery<TResult> { }
public record GetOrderByIdQuery(int OrderId) : IGetQuery<int>;

public interface IGetQueryHandler<TQuery, TResult> 
    where TQuery : IGetQuery<TResult>
{
    Task<TResult> Run(TQuery query, CancellationToken ct = default);
}