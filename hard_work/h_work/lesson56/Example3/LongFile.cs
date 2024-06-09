namespace h_work.lesson56.Example3;




#region Contracts

public interface IAllowAccountOpeningService
{
    Task<AccountOpeningCheckResult> CheckIsAllowed(Guid companyId, bool eventIfNo = true);
    Task Allow(Guid companyId, InternalUserInfo user, RequestClientInfo clientInfo);
}
public record AccountOpeningCheckResult
{
    /// <summary>
    /// Разрешено автоматическое открытие счёта
    /// </summary>
    public bool IsAllowed { get; set; }
    /// <summary>
    /// Стриггерены таски
    /// </summary>
    public bool HasTriggeredTasks { get; set; }
    /// <summary>
    /// Нужно разрешить вручную
    /// </summary>
    public bool HasManualOpening { get; set; }
}

#endregion


#region ExtendedAutoFinishFeature
public class CddReviewAutoFinishFeatureService 
{
    private static readonly EFeatures FEATURE_CODE = EFeatures.CddReviewAutoFinish;
    
    private readonly IFeatureToggleHelper _featureToggleHelper;
    private readonly IDbMapper _dbMapper;

    public CddReviewAutoFinishFeatureService(IFeatureToggleHelper featureToggleHelper, IDbMapper dbMapper)
    {
        _featureToggleHelper = featureToggleHelper;
        _dbMapper = dbMapper;
    }

    public Task<bool> IsAvailableByCompanyId(Guid companyId) => _featureToggleHelper.IsAvailableAsync(FEATURE_CODE, companyId.ToString());

    public Task<bool> IsAvailableByCountry(string countryCode) => _featureToggleHelper.IsAvailableAsync(FEATURE_CODE, countryCode.ToUpper());
    public Task<bool> IsAvailableByFreelancer(string countryCode) => _featureToggleHelper.IsAvailableAsync(FEATURE_CODE, $"{countryCode.ToUpper()}_Freelancer");

    public async Task<bool> IsDisabledByLegalForm(string countryCode, Guid legalFormId)
    {
        var sql = @"select exists(select clientid from featuretoggling.features_clientaccess
			  where clientid = @clientid
			  and state = @state and code = @code
			 )";

        return await _dbMapper.ExecuteScalarAsync<bool>(sql,
            new
            {
                state = EFeatureState.Disabled.ToString(), 
                code = FEATURE_CODE.ToString(), 
                clientid = $"{countryCode}_LF_{legalFormId}"
            });
    }
}


#endregion


#region OpenAccountParameters

public static class OpenAccountParameters
{
    public const string Auto = "auto";
    public const string Button = "button";
    public const string Review = "review";
    
    public static string Calc(AccountOpeningCheckResult allowed)
    {
        if (allowed.HasTriggeredTasks) return Review;
        if (allowed.HasManualOpening) return Button;
        return Auto;
    }
}

#endregion


public class AllowAccountOpeningService : IAllowAccountOpeningService
{
    private readonly CddReviewAutoFinishFeatureService _featureToggle;
    private readonly ICompanyInfoGetter _companyInfoGetter;
    private readonly ITicketsService _ticketsService;
    private readonly ICompleteUserTaskService _completeUserTaskService;
    private readonly SimpleInhouseAuditHelper _simpleInhouseAuditHelper;
    private readonly IHydeParkPublisher _hydeParkPublisher;
    private readonly ICustomerDossierOuterService _dossierOuterService;
    private readonly AllowAccountOpeningNotification _allowAccountOpeningNotification;
    private readonly IDbMapper _dbMapper;


    private const string UserTaskName = "WaitForAllowOpenAccountResolve";

    public AllowAccountOpeningService(
        CddReviewAutoFinishFeatureService featureToggle,
        ICompanyInfoGetter companyInfoGetter,
        ITicketsService ticketsService,
        ICompleteUserTaskService completeUserTaskService,
        SimpleInhouseAuditHelper simpleInhouseAuditHelper,
        IHydeParkPublisher hydeParkPublisher,
        AllowAccountOpeningNotification allowAccountOpeningNotification, ICustomerDossierOuterService dossierOuterService, IDbMapper dbMapper)
    {
        _featureToggle = featureToggle;
        _companyInfoGetter = companyInfoGetter;
        _ticketsService = ticketsService;
        _completeUserTaskService = completeUserTaskService;
        _simpleInhouseAuditHelper = simpleInhouseAuditHelper;
        _hydeParkPublisher = hydeParkPublisher;
        _allowAccountOpeningNotification = allowAccountOpeningNotification;
        _dossierOuterService = dossierOuterService;
        _dbMapper = dbMapper;
    }

    public async Task Allow(Guid companyId, InternalUserInfo user, RequestClientInfo clientInfo)
    {
        var tickets = await _ticketsService.GetTicketsByGroupKey(companyId.ToString());
        var cddTicket = tickets.FirstOrDefault(x => x.TicketType == ETicketType.CddReview);
        cddTicket.ContractNotNull("CDD ticket not found");

        var ticketContext = TicketContext.ByTicket(cddTicket);
        await _completeUserTaskService.CompleteUserTask(ticketContext, UserTaskName);

        var companyInfo = await _companyInfoGetter.GetCompanyInfo(companyId);
        await _simpleInhouseAuditHelper.SimpleInhouseAuditEvent(companyInfo, "Payment account opened", user, clientInfo);
        await PublishAllowOpenAccountInhouseMessage(companyId, true);

        await _allowAccountOpeningNotification.Send(ticketContext, companyInfo, user);

        await _hydeParkPublisher.PublishAsync(new SetDossierOwnerIfEmptyMessage()
        {
            CompanyId = companyId,
            OwnerId = user.Id
        });
    }

    public async Task<AccountOpeningCheckResult> CheckIsAllowed(Guid companyId, bool eventIfNo = true)
    {
        var result = new AccountOpeningCheckResult();
        if (await _ticketsService.HasTriggeredTasks(companyId))
        {
            result.IsAllowed = true;
            result.HasManualOpening = false;
            result.HasTriggeredTasks = true;
            return result;
        }

        var dossierCompany = await _dossierOuterService.GetCompanyInfo(companyId);
        var dossier = await _dossierOuterService.GetCompanyFlags(companyId);

        if (dossier.NoLrsFromRegistry)
        {
            if (eventIfNo)
            {
                await _allowAccountOpeningNotification.SendNoLrs(dossierCompany);
                await PublishAllowOpenAccountInhouseMessage(companyId, false);
            }

            result.IsAllowed = false;
            result.HasManualOpening = true;
            result.HasTriggeredTasks = false;

            return result;
        }

        result.IsAllowed = await _featureToggle.IsAvailableByCompanyId(companyId);
        if (!result.IsAllowed)
        {
            result.IsAllowed = await IsAllowedByCompanyType(dossierCompany);
        }

        result.HasManualOpening = !result.IsAllowed;

        if (eventIfNo && !result.IsAllowed)
        {
            await _allowAccountOpeningNotification.SendIfAllowed(dossierCompany);
            await PublishAllowOpenAccountInhouseMessage(companyId, result.IsAllowed);
        }

        return result;
    }

    private Task<bool> IsAllowedByCompanyType(CustomerDossierCompanyInfoResponse company)
    {
        return company.CompanyType switch
        {
            EDossierCompanyType.UnregisteredFreelancer => _featureToggle.IsAvailableByFreelancer(company.CountryCode),
            _ => IsAutoOpeningEnabledForCompany(company)
        };
    }

    private async Task<bool> IsAutoOpeningEnabledForCompany(CustomerDossierCompanyInfoResponse company)
    {
        bool enabledByCountry = await _featureToggle.IsAvailableByCountry(company.CountryCode);
        if (enabledByCountry && company.LegalFormId != null)
        {
            bool isDisabledByLegalForm = await _featureToggle.IsDisabledByLegalForm(company.CountryCode, company.LegalFormId.Value);
            if (isDisabledByLegalForm) return false;
        }

        return enabledByCountry;
    }

    private Task PublishAllowOpenAccountInhouseMessage(Guid companyId, bool isAllowed)
    {
        return _hydeParkPublisher.PublishAsync(new AllowOpenAccountInhouseHydeParkMessage
        {
            CompanyId = companyId,
            AllowOpenAccount = isAllowed
        });
    }

    private static string GetFreelancerFeatureValue(CustomerDossierCompanyInfoResponse company)
    {
        return $"{company.CountryCode.ToUpper()}_Freelancer";
    }
}
