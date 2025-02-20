namespace h_work.lesson93.Example3;

public class Before
{
    /*
     public interface ICountryRegNumberValidationService
    {
        public string CountryCode { get; }
        Task<RegNumberDetails> Validate(RegNumberValidationModel model);
    }

     * public async Task<RegNumberDetails> Validate(RegNumberValidationModel model)
    {
        var service = _countryServices.GetValueOrDefault(model.CountryCode)
                      ?? _countryServices.GetValueOrDefault(CountryCodes.All)
                      ?? throw new NotImplementedException($"Country '{model.CountryCode}' validation service not implemented");

        try
        {
            return await service.Validate(model);
        }
        catch (CustomWebException ex)
            when (ex is RegNumberInvalidCustomWebException or RegNumberNotExistInDataSourceCustomWebException)
        {
            var canSkipValidation = await _featureToggleHelper.IsAvailableAsync(EFeatures.SkipRegNumberValidation, model.CompanyId);
            if (canSkipValidation)
            {
                var companyInfo = await _companyInfoGetter.GetShortCompanyInfo(model.CompanyId);
                // Suppress RegistrationNumber validation failure
                return new RegNumberDetails(companyInfo?.Name, string.Empty);
            }

            throw;
        }
    }

    public async Task<RegNumberDetails> ValidateAndThrow(IBankOnboardingContext context, RegNumberValidationModel model,
        RequestClientInfo requestClientInfo)
    {
        try
        {
            return await Validate(model);
        }
        catch (RegNumberAlreadyRegisteredCustomWebException)
        {
            await AnalyticsAlreadyExists(context, requestClientInfo, model.RegNumber);
            throw;
        }
        catch (RegNumberNotExistInDataSourceCustomWebException)
        {
            await AnalyticsNotFoundInDataSource(context, requestClientInfo, model.RegNumber, model.RegistrationIssuerId);
            throw;
        }
        catch (CustomWebException cwex) when (cwex is RegNumberInvalidCustomWebException or RegistrationIssuerInvalidCustomWebException)
        {
            await AlertInvalidRegNumber(context, requestClientInfo, model.RegNumber);
            throw;
        }
    }
     */
}