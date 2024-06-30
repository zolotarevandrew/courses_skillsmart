using h_work.lesson18.part1.example2;

namespace h_work.lesson59.Example2;

public static class MissDataPointFuncs
{
    public static bool IsLegalRepMissing(IBankOnboardingContext context)
    {
        //tbd base algo here
        return false;
    }
    
    public static bool IsGbrLegalRepMissing(IBankOnboardingContext context)
    {
        //tbd base algo here wuth some changes
        return IsLegalRepMissing(context);
    }
}

/*

public class FinomGermanGbrCompanyMissingInformationService : BaseFinomBusinessMissingInformationService
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
            EBusinessMissingDataPoint.LegalRepresentatives => await NeedToDeclareLegalRepresentatives(context),
            _ => throw new NotImplementedException(),
        };

        return new MissingInfoByDataPoint
        {
            DataPoint = dataPoint,
            IsMissing = isMissing
        };
    }
    
     private async Task<bool> NeedToDeclareLegalRepresentatives(IBankOnboardingContext context)
    {
        var result = await MissDataPointFuncs.IsGbrLegalRepMissing(context.CompanyId);
        if (result)
        {
            await OnboardingMetadata.SetKey(context, BankOnboardingDataKeys.Finom.NeedToDeclareLegals, true);
        }

        return result;
    }
}
*/