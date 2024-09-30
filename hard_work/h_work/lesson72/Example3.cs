namespace h_work.lesson72;

/*
public class CompanyInStorage {}
public class SilentCddReviewDataValidationService
{    
    private readonly ILogger<SilentCddReviewDataValidationService> _logger;
    private readonly ICompanyDossierStorageService _companyDossierStorage;
    private readonly ICompanyTransactionProfileStorageService _companyTransactionProfileStorageService;
    private readonly IBeforeStartCddDataValidationServiceForMigration _beforeStartCddDataValidation;
    private readonly IAfterVerificationsCddDataValidationServiceForMigration _afterVerificationsCddDataValidation;
    
    public SilentCddReviewDataValidationService(ICompanyDossierStorageService companyDossierStorage,
        ICompanyTransactionProfileStorageService companyTransactionProfileStorageService,
        IBeforeStartCddDataValidationServiceForMigration beforeStartCddDataValidation,
        IAfterVerificationsCddDataValidationServiceForMigration afterVerificationsCddDataValidation,
        ILogger<SilentCddReviewDataValidationService> logger)
    {
        _companyDossierStorage = companyDossierStorage;
        _companyTransactionProfileStorageService = companyTransactionProfileStorageService;
        _beforeStartCddDataValidation = beforeStartCddDataValidation;
        _afterVerificationsCddDataValidation = afterVerificationsCddDataValidation;
        _companyPersonStorage = companyPersonStorage;
        _logger = logger;
        _hydeParkPublisher = hydeParkPublisher;
        _userInfoGetter = userInfoGetter;
    }
    
    public async Task<ValidationCheckResult> Check(Guid companyId, Guid registarUserId)
    {
        try
        {
            var company = await _companyDossierStorage.Get(companyId);
        
            var validationResults = await Task.WhenAll(
                MandatoryDataValidation(company),
                LegalEntitiesValidation(companyId, registarUserId),
                _afterVerificationsCddDataValidation.Validate(company),
                _beforeStartCddDataValidation.Validate(company)
            );
            
            if (validationResults.All(x => x.IsSuccess))
            {
                return ValidationCheckResult.Success;
            }
            
            var errors = validationResults
                .Where(x => !x.IsSuccess)
                .SelectMany(result => result.Errors)
                .ToList();
            
            return ValidationCheckResult.Fail(errors.ToArray());
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Failed migration completness check for CompanyId: {CompanyId}", companyId);
            return ValidationCheckResult.Fail($"Failed migration completness check {e.Message}");
        }
    }
    
    private async Task<ValidationCheckResult> MandatoryDataValidation(CompanyInStorage companyInfo)
    {
        throw new NotImplementedException();
    }
    
    private async Task<ValidationCheckResult> LegalEntitiesValidation(Guid companyId, Guid registrarUserId)
    {
        throw new NotImplementedException();
    }
}

public record ValidationCheckResult
{
    public bool IsSuccess { get; private set; }
    
    public IReadOnlyCollection<string> Errors { get; private set; }
    
    public ValidationCheckResult(bool isSuccess,  params string[] errors)
    {
        IsSuccess = isSuccess;
        Errors = errors ?? Array.Empty<string>();
    }
    
    public static ValidationCheckResult Success => new(true);
    public static ValidationCheckResult Fail(params string[] errors) => new(false, errors);
}
*/