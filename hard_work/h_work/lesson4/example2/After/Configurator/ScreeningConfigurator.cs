using h_work.lesson4.example2.After.Parameters;

namespace h_work.lesson4.example2.After.Configurator;


public delegate Task ScreeningConfigurationDelegate(ScreeningParameter parameter,ScreenResult result);


public interface IScreeningConfigurator
{
    IScreeningConfigurator OnSuccess(ScreeningConfigurationDelegate success);
    IScreeningConfigurator OnFail(ScreeningConfigurationDelegate fail);
    IScreeningRunner Apply();
}
public class ScreeningConfigurator : IScreeningConfigurator
{
    private readonly IScreeningService _screeningService;
    
    private ScreeningConfigurationDelegate _success;
    private ScreeningConfigurationDelegate _fail;

    public ScreeningConfigurator(IScreeningService screeningService)
    {
        _screeningService = screeningService;
    }
    public IScreeningConfigurator OnSuccess(ScreeningConfigurationDelegate success)
    {
        _success = success;
        return this;
    }
    
    public IScreeningConfigurator OnFail(ScreeningConfigurationDelegate fail)
    {
        _fail = fail;
        return this;
    }
    
    public IScreeningRunner Apply()
    {
        return new ScreeningRunner(
            _screeningService,
            _success,
            _fail
        );
    }
}