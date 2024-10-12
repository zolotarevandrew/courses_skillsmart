namespace h_work.lesson75;

/*
 * using Flurl.Http;
using Flurl.Http.Configuration;
using IdCheck.SumSub.Configs;
using IdCheck.SumSub.Integration.HttpCallbacks;

namespace IdCheck.SumSub.Integration;

public interface ISumSubClientFactory
{
    ISumSubClient Create();
}

public class BaseSumSubClientFactory : ISumSubClientFactory
{
    private readonly IFlurlClientFactory _clientFactory;
    private readonly SumSubApiConfig _config;
    private readonly SigningRequestHttpCallback _signingRequestHttpCallback;
    private readonly LoggingHttpCallback _loggingHttpCallback;

    public BaseSumSubClientFactory(
        SumSubApiConfig config, 
        IFlurlClientFactory clientFactory,
        
        LoggingHttpCallback loggingHttpCallback, 
        SigningRequestHttpCallback signingRequestHttpCallback)
    {
        _loggingHttpCallback = loggingHttpCallback;
        _signingRequestHttpCallback = signingRequestHttpCallback;
        _config = config;
        _clientFactory = clientFactory;
    }
    
    public ISumSubClient Create()
    {
        var client = _clientFactory.Get(_config.Uri);
        client.Configure(s =>
        {
            s.BeforeCallAsync = _signingRequestHttpCallback.ExecuteAsync;
            s.AfterCallAsync = _loggingHttpCallback.ExecuteAsync;
        });
        return new SumSubClient(client, _config);
    }
}
*/