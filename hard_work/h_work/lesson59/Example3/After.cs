namespace h_work.lesson59.Example3;

/*
 * public record AobBannerRequest(Guid CompanyId, Guid UserId, EAobBannerType Type, object CustomData = null);
public static class FunctionalAobBanner
{
    private static readonly JsonSerializer JsonSerializer = new()
    {
        ContractResolver = new CamelCasePropertyNamesContractResolver(),
        NullValueHandling = NullValueHandling.Ignore
    };

    public static async Task Activate(
        AobBannerRequest request,
        IAOBBannerService bannerService,
        IBankOnboardingAobPusher aobPusher)
    {
        await bannerService.Upsert(new UpsertBannerEntity(request.CompanyId, request.Type)
        {
            CompanyId = request.CompanyId,
            UserId = request.UserId,
            NewStatus = EAobBannerStatus.Active,
            NewAobState = EBankOnboardingAobState.Normal,
            Metadata = request.CustomData != null
                ? JObject.FromObject(request.CustomData, JsonSerializer)
                : null
        });
        await aobPusher.Refresh(request.CompanyId, request.UserId);
    }
}

public interface IBannerActivator 
{
   Task Activate(AobBannerRequest request);
}

public class DataCollectionRequiredBannerActivator : IBannerActivator
{
    public DataCollectionRequiredBannerActivator(IAOBBannerService aobBannerService, IBankOnboardingAobPusher aobPusher)
    {
    }


    public async Task Activate(AobBannerRequest request)
    {
        //можем вставлять этот код куда хотим в разных последовательностях и легко добавлять свой
        await FunctionalAobBanner.Activate(request, aobBannerService, aobPusher);
    }
}


*/