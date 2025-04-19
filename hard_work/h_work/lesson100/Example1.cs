namespace h_work.lesson100;

public async Task ProcessAsync(string id, CancellationToken cancellationToken = default)
{
    await Task.Delay(1000, cancellationToken);
}