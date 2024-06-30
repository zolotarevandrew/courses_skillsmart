namespace h_work.lesson59.Example2;

/*
 * public abstract class BaseFinomGermanBusinessMissingInformationService : BaseFinomBusinessMissingInformationService
{
    private readonly IPersonInfoMissingService _personMissingService;

    public BaseFinomGermanBusinessMissingInformationService(
        IBankOnboardingMetadataService onboardingMetadata,
        IPersonInfoMissingService personMissingService)
        : base(onboardingMetadata)
    {
        _personMissingService = personMissingService;
    }
    protected override bool CheckAllowed(EBusinessMissingDataPoint dataPoint)
    {
        return dataPoint.In(
            EBusinessMissingDataPoint.Addresses,
            EBusinessMissingDataPoint.RegistrationDocument,
            EBusinessMissingDataPoint.LegalRepresentatives);
    }

    protected override async Task<MissingInfoByDataPoint> GetByDataPoint(IBankOnboardingContext context,
        EBusinessMissingDataPoint dataPoint,
        BusinessMissingDataPoints missingDataPoints)
    {
        var isMissing = dataPoint switch
        {
            EBusinessMissingDataPoint.Addresses => await CompanyAddressesMissing(context),
            EBusinessMissingDataPoint.RegistrationDocument => await RegistrationDocumentsMissing(context),
            EBusinessMissingDataPoint.LegalRepresentatives => await NeedToDeclareLegalRepresentatives(context),
            _ => throw new NotImplementedException(),
        };

        return new MissingInfoByDataPoint
        {
            DataPoint = dataPoint,
            IsMissing = isMissing
        };
    }

    private async Task<bool> CompanyAddressesMissing(IBankOnboardingContext context)
    {
        await OnboardingMetadata.SetKey(context, BankOnboardingDataKeys.Finom.AddressMissing, true);
        return true;
    }

    private async Task<bool> RegistrationDocumentsMissing(IBankOnboardingContext context)
    {
        await OnboardingMetadata.SetKey(context, BankOnboardingDataKeys.Finom.RegistrationDocumentsMissing, true);
        return true;
    }

    private async Task<bool> NeedToDeclareLegalRepresentatives(IBankOnboardingContext context)
    {
        var result = await _personMissingService.MissingLegalInfo(context.CompanyId);
        if (result)
        {
            await OnboardingMetadata.SetKey(context, BankOnboardingDataKeys.Finom.NeedToDeclareLegals, true);
        }

        return result;
    }
}

public class FinomGermanGbrCompanyMissingInformationService : BaseFinomGermanBusinessMissingInformationService
{
    public FinomGermanGbrCompanyMissingInformationService(
        IBankOnboardingMetadataService onboardingMetadata,
        IPersonInfoMissingService personMissingService)
        : base(onboardingMetadata, personMissingService)
    {
    }

    protected override bool CheckAllowed(EBusinessMissingDataPoint dataPoint)
    {
        return dataPoint.In(
            EBusinessMissingDataPoint.Addresses,
            EBusinessMissingDataPoint.LegalRepresentatives);
    }
    
    protected override async Task<MissingInfoByDataPoint> GetByDataPoint(IBankOnboardingContext context,
        EBusinessMissingDataPoint dataPoint,
        BusinessMissingDataPoints missingDataPoints)
    {
        var isMissing = dataPoint switch
        {
            EBusinessMissingDataPoint.Addresses => await CompanyAddressesMissing(context),
            EBusinessMissingDataPoint.RegistrationDocument => await RegistrationDocumentsMissing(context),
            EBusinessMissingDataPoint.LegalRepresentatives => await NeedToDeclareLegalRepresentatives(context),
            _ => throw new NotImplementedException(),
        };

        return new MissingInfoByDataPoint
        {
            DataPoint = dataPoint,
            IsMissing = isMissing
        };
    }
}
*/