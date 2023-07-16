using Flurl.Http;

namespace h_work.lesson13.example3;

public interface IPublisher
{
    Task PublishAsync<TMessage>(TMessage message);
}

public class SomeExternalSystemLoggingHttpCallback
{
    private readonly IPublisher _publisher;

    public SomeExternalSystemLoggingHttpCallback(IPublisher publisher)
    {
        _publisher = publisher;
    }

    public async Task ExecuteAsync(FlurlCall call)
    {
        var responseAsString = await GetResponseAsString(call);

        await _publisher.PublishAsync(new RequestLogMessage
        {
            Created = call.StartedUtc,
            Duration = call.Duration ?? TimeSpan.Zero,
            
            Service = "ourservice",
            StatusCode = call.Response?.StatusCode ?? 500,
            
            Request = $"{call.HttpRequestMessage.Method} {call.HttpRequestMessage.RequestUri} {call.RequestBody}",
            Response = string.IsNullOrEmpty(responseAsString) ? call.Exception?.Message : responseAsString
        });
    }
    
    async Task<string> GetResponseAsString(FlurlCall call)
    {
        var response = call.HttpResponseMessage;
        if (response == null) return string.Empty;

        var res = await response.Content.ReadAsStringAsync();
        
        //some custom logic here
        
        return res;
    }
}

public class RequestLogMessage
{
    public string Request { get; set; }
    public string? Response { get; set; }
    public int StatusCode { get; set; }
    public string Service { get; set; }
    public DateTime Created { get; set; }
    public TimeSpan Duration { get; set; }
}
