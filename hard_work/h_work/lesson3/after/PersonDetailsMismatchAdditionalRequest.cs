namespace h_work.lesson3.after;

public interface IPusher
{
    Task Push();
}

public interface IEmailNotification
{
    Task Send();
}

public interface IUserInfo
{
    Task<object> GetShortUserInfo(Guid contextUserId);
}
public class PersonDetailsMismatchAdditionalRequest : ByAobBannerAdditionalRequest
{
    private readonly IObaStatusService _obaStatusService;
    private readonly IPusher _pusher;
    private readonly IEmailNotification _emailNotificationService;
    private readonly IUserInfo _userInfoGetter;

    public PersonDetailsMismatchAdditionalRequest(
        IObaStatusService obaStatusService,
        IBannerService bannerService,
        IPusher pusher,
        IEmailNotification emailNotificationService, IUserInfo userInfoGetter) : base(bannerService)
    {
        _obaStatusService = obaStatusService;
        _pusher = pusher;
        _emailNotificationService = emailNotificationService;
        _userInfoGetter = userInfoGetter;
        _pusher = pusher;
        _emailNotificationService = emailNotificationService;
        _userInfoGetter = userInfoGetter;
    }

    protected override BannerType BannerType => BannerType.DetailsMismatch;
    protected override async Task CreateInternal(CreateOnboardingAdditionalRequest request)
    {
        var context = request.Context;
        await _obaStatusService.SetObaStatus(context, EObaStatus.PersonDetailsMismatch);
        await _pusher.Push();
        var user = await _userInfoGetter.GetShortUserInfo(context.UserId);
        //some details hidden here
        await _emailNotificationService.Send();
    }
}

public enum EObaStatus
{
    PersonDetailsMismatch
}

public interface IObaStatusService
{
    Task SetObaStatus(OnboardingContext context, object obaFreelancerDetailsMismatch);
}

