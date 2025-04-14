namespace h_work.lesson99.Example1;

[HttpGet("ip-orgs/entities")]
public async Task<IEnumerable<ContragentSearchDto>> GetIpOrgsEntities([FromQuery] string search = "")
{
    var res = await _repo.GetIpOrgsAsync(search);
    return res.Select(r => new ContragentSearchDto
    {
        Id = r.Id,
        Name = r.ToIpOrgName(),
        FullName = r.Name.Value,
        Type = r.Type
    });
}
        
[HttpGet("by-passport/entities")]
public async Task<IEnumerable<SearchOptionDto>> GetByPassportEntities([FromQuery] string search = "")
{
    var res = await _repo.SearchByPassportAsync(search);
    return res.Select(r => new SearchOptionDto
    {
        Id = r.Id,
        Name = r.ToByPassportName()
    });
}