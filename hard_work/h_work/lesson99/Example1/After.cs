namespace h_work.lesson99.Example1;

public abstract class HttpQuery<TRequest, TResult>
{
    //add some http context in here
    
    public abstract Task<TResult> ExecuteAsync(TRequest request, IServiceProvider services);
}

public class GetByPassport : HttpQuery<GetByPassportRequest, List<SearchOptionDto>>
{
    public override async Task<List<SearchOptionDto>> ExecuteAsync(
        GetByPassportRequest request, IServiceProvider services)
    {
        var db = services.GetRequiredService<AppDbContext>();
        var result = await db.Contragents
            .Where(c => c.Passport.Contains(request.Search))
            .Select(c => new SearchOptionDto
            {
                Id = c.Id,
                Name = c.ToByPassportName()
            })
            .ToListAsync();

        return result;
    }
}