using h_work.lesson4.example2.After.Configurator;
using h_work.lesson4.example2.After.Parameters;
using h_work.lesson4.example2.After.Sharing;

namespace h_work.lesson4.example2.After;

public class PrepareSanctionsCheckSourceHandler
{
    private readonly ICompanyService _companyService;
    private readonly IScreeningConfigurator _screeningConfigurator;
    private readonly ISanctionListsService _sanctionListsService;
    private readonly IRiskService _riskService;
    private readonly IScreeningParameterSharer _screeningParameterSharer;

    public PrepareSanctionsCheckSourceHandler(
        ICompanyService companyService,
        ISanctionListsService sanctionListsService, 
        IRiskService riskService, 
        IScreeningConfigurator screeningConfigurator, 
        IScreeningParameterSharer screeningParameterSharer)
    {
        _companyService = companyService;
        _sanctionListsService = sanctionListsService;
        _riskService = riskService;
        _screeningConfigurator = screeningConfigurator;
        _screeningParameterSharer = screeningParameterSharer;
    }

    public async Task<List<ScreeningParameter>> Prepare(Guid companyId)
    {
        var company = await _companyService.Get(companyId);
        var sanctionLists = await _sanctionListsService.Get(ESanctionsType.Sanctions);
        
        var parameters = new List<ScreeningParameter>();
        
        parameters.AddRange(company
            .TradeNames
            .Select(c => new CompanyTradeNameScreeningParameter(companyId, c))
        );
        parameters.Add(new CompanyRegisteredNameScreeningParameter(companyId, company.RegisteredName));
        
        parameters.AddRange(company
            .Persons
            .Select(person => new PersonFullNameScreeningParameter(companyId, person))
        );
        
        foreach (var parameter in parameters)
        {
            var screeningRunner = _screeningConfigurator
                .OnSuccess((p, s) => _riskService.Init(p.ToRiskRequest()))
                .OnFail((p, s) => _screeningParameterSharer.ShareBetweenSameType(p, s))
                .Apply();
            await screeningRunner.RunFor(parameter, sanctionLists);
        }

        return parameters;
    }
}

public static class RiskExtensions
{
    public static InitRiskRequest ToRiskRequest(this ScreeningParameter parameter)
    {
        return new InitRiskRequest
        {
            CompanyId = parameter.CompanyId,
            EntityId = parameter.EntityId,
            EntityType = parameter.EntityType,
            Parameter = parameter.Type,
            ParameterId = parameter.Id
        };
    }
}