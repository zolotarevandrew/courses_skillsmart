namespace h_work.lesson99.Example3;

[HttpPost("list")]
public async Task<DictListResponse> GetList([FromBody] DictListRequest request)
{
    return await _processor
        .GetQuery<GetDictListQueryHandler>()
        .QueryAsync(new GetDictListQuery(request));
}

public class GetDictListQueryHandler : IQueryHandler<GetDictListQuery, DictListResponse>
{
    IDictSettingsRepository _repository;

    public GetDictListQueryHandler(IDictSettingsRepository repository)
    {
        _repository = repository;
    }

    public async Task<DictListResponse> QueryAsync(GetDictListQuery query)
    {
        var filterRequest = query.Request.ToFilterRequest();
        var result = await _repository.GetFilteredAsync(filterRequest);
        var response = new DictListResponse
        {
            TotalCount = result.TotalCount,
            Items = result.Items
                .Select(c => c.ToDictListItemDto())
                .ToList(),
            Filters = result.Items
                .ToDictListFilters(FiltersConsts.Dict.Metadata)
                .FromRequestFilters(query.Request.Filters)
        };
        return response;
    }
}

public interface IDictSettingsRepository : IAsyncRepository<DictSettings>
{
    Task<DictSettings?> GetByCodeAsync(string code);
    Task<FiltersResponse<DictSettings>> GetFilteredAsync(FilterRequest request);
}