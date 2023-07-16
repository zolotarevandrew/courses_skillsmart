using Flurl.Http;
using Microsoft.Extensions.Logging;

namespace h_work.lesson13.example3;

public interface ILoggingHttpCallback
{
    Task ExecuteAsync(FlurlCall call);
}

public abstract class BaseLoggingHttpCallback : ILoggingHttpCallback
{
    //здесь конечно же будет Енумка, не заводил лишний раз, оставил так для примера
    
    protected abstract string Registry { get; }
    protected readonly IPublisher Publisher;
    protected readonly ILogger<ILoggingHttpCallback> Logger;
    protected BaseLoggingHttpCallback(
        IPublisher publisher,
        ILogger<ILoggingHttpCallback> logger
      )
    {
        Publisher = publisher;
        Logger = logger;
    }

    public async Task ExecuteAsync(FlurlCall call)
    {
        if (!call.Succeeded)
        {
            await LogError(call);
        }

        var response = await GetResponseAsString(call);
        var sanitizedResponse = await SanitizeResponse(call, response);
        var request = await GetRequestAsString(call);
        await Publisher.PublishAsync(new RequestLogMessage
        {
            Created = call.StartedUtc,
            Duration = call.Duration ?? TimeSpan.Zero,

            Service = "ourservice",
            StatusCode = call.Response?.StatusCode ?? 500,

            Request = request,
            Response = string.IsNullOrEmpty(sanitizedResponse) ? call.Exception?.Message : sanitizedResponse
        });
    }

    protected abstract Task<string> GetResponseAsString(FlurlCall call);

    protected abstract Task<string> GetRequestAsString(FlurlCall call);

    //шифруем персональную информацию
    protected abstract Task<string> SanitizeResponse(FlurlCall call, string rawResponse);

    protected virtual Task LogError(FlurlCall call)
    {
        var exception = call.Exception;

        if (exception is OperationCanceledException { CancellationToken.IsCancellationRequested: false })
        {
            Logger.Log(LogLevel.Warning, call.Exception, "Request to registry {registryName} {verb} {url} has timed out after {duration}", Registry, call.Request.Verb, call.Request.Url, call.Duration);
            return Task.CompletedTask;
        }

        Logger.Log(LogLevel.Warning, call.Exception, "Request to registry {registryName} {verb} {url} has failed with status code {statusCode}", Registry, call.Request.Verb, call.Request.Url, call.Response?.StatusCode ?? 500);

        return Task.CompletedTask;
    }
}

public abstract class RestServiceLoggingHttpCallback : BaseLoggingHttpCallback
{
    protected RestServiceLoggingHttpCallback(IPublisher publisher, ILogger<ILoggingHttpCallback> logger) : base(
        publisher, logger)
    {
    }

    protected override async Task<string> GetResponseAsString(FlurlCall call)
    {
        var response = call.HttpResponseMessage;
        if (response == null)
            return string.Empty;

        var res = await response.Content.ReadAsStringAsync();
        var errorMessage = HandleResponseError(call, res);

        return string.IsNullOrEmpty(errorMessage) ? res : errorMessage;
    }

    protected override Task<string> GetRequestAsString(FlurlCall call)
    {
        var request = $"{call.HttpRequestMessage.Method} {call.HttpRequestMessage.RequestUri} {call.RequestBody}";
        return Task.FromResult(request);
    }

    protected virtual string HandleResponseError(FlurlCall call, string responseString)
    {
        return string.Empty;
    }
}


public class SomeServiceLoggingHttpCallback : RestServiceLoggingHttpCallback
{
    protected override string Registry => "SomeRegistry";
    
    public SomeServiceLoggingHttpCallback(IPublisher publisher, ILogger<ILoggingHttpCallback> logger) : base(publisher, logger)
    {
    }

    protected override async Task<string> SanitizeResponse(FlurlCall call, string rawResponse)
    {
        return rawResponse;
    }

}