using h_work.lesson4.example2.After.Parameters;

namespace h_work.lesson4.example2.After.Configurator;

public interface IScreeningRunner
{
    Task RunFor(ScreeningParameter parameter, SanctionList sanctionList);
}

public class ScreeningRunner : IScreeningRunner
{
    private readonly ScreeningConfigurationDelegate _success;
    private readonly ScreeningConfigurationDelegate _fail;
    private readonly IScreeningService _screeningService;

    public ScreeningRunner(
        IScreeningService screeningService, 
        ScreeningConfigurationDelegate success, 
        ScreeningConfigurationDelegate fail)
    {
        _screeningService = screeningService;
        _success = success;
        _fail = fail;
    }
    
    public async Task RunFor(ScreeningParameter parameter, SanctionList sanctionList)
    {
        var isOrganizationParameter = parameter.EntityType is EEntityType.Company or EEntityType.LegalEntity;
        
        var sharedKey = parameter.SharedKey;
        var screened = await _screeningService.Screen(
            new ScreenDataRequest(
                parameter.EntityId,
                parameter.ScreeningValue,
                sharedKey.Value,
                isOrganizationParameter
            )
        );
        
        if (screened.HasSanctionsType(sanctionList))
        {
            await _success(parameter, screened);
            return;
        }
        
        await _fail(parameter, screened);
    }
}