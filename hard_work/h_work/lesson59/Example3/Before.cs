namespace h_work.lesson59.Example3;

/*
 * public abstract class AobBannerActivator
{
    private readonly IAOBBannerService _aobBannerService;
    private readonly IBankOnboardingAobPusher _aobPusher;

    protected abstract EAobBannerType BannerType { get; }

    private static readonly JsonSerializer JsonSerializer = new()
    {
        ContractResolver = new CamelCasePropertyNamesContractResolver(),
        NullValueHandling = NullValueHandling.Ignore
    };

    protected AobBannerActivator(IAOBBannerService aobBannerService, IBankOnboardingAobPusher aobPusher)
    {
        _aobBannerService = aobBannerService;
        _aobPusher = aobPusher;
    }

    public async Task Activate(AobBannerRequest request)
    {
        await ActivateInternal(request);
        await _aobBannerService.Upsert(new UpsertBannerEntity(request.CompanyId, BannerType)
        {
            CompanyId = request.CompanyId,
            UserId = request.UserId,
            NewStatus = EAobBannerStatus.Active,
            NewAobState = EBankOnboardingAobState.Normal,
            Metadata = request.CustomData != null
                ? JObject.FromObject(request.CustomData, JsonSerializer)
                : null
        });
        await _aobPusher.Refresh(request.CompanyId, request.UserId);
    }

    protected abstract Task ActivateInternal(AobBannerRequest request);
}

public class DataCollectionRequiredBannerActivator : AobBannerActivator
{
    public DataCollectionRequiredBannerActivator(IAOBBannerService aobBannerService, IBankOnboardingAobPusher aobPusher) : base(aobBannerService, aobPusher)
    {
    }

    protected override EAobBannerType BannerType => EAobBannerType.DataCollectionRequired;

    protected override Task ActivateInternal(AobBannerRequest request)
    {
        return Task.CompletedTask;
    }
}


*/