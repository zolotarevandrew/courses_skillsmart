namespace h_work.lesson99.Example2;

[HttpPost("create")]
public async Task<IActionResult> Create([FromBody] CreateStatementDto dto)
{
    await _processor
        .GetCommand<CreateStatementCommandHandler>()
        .ExecuteAsync(new CreateStatementCommand(dto));

    return Ok();
}

public interface IStatementDomainService
{
    Task CreateAsync(Statement statement);
}