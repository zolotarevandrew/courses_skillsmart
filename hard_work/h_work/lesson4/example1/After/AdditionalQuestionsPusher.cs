namespace h_work.lesson4.example1.After;

public interface IAdditionalQuestionsPusher
{
    Task SendWebPush(PushAdditionalQuestionsModel model);
    Task SendMobilePush(PushAdditionalQuestionsModel model);
}

public class AdditionalQuestionsPusher : IAdditionalQuestionsPusher
{
    private readonly IPublisher _publisher;
    private readonly IPushService _pushService;
    private readonly ILocalizationService _localizationService;
    public AdditionalQuestionsPusher(
        IPublisher publisher, 
        IPushService pushService, 
        ILocalizationService localizationService)
    {
        _publisher = publisher;
        _pushService = pushService;
        _localizationService = localizationService;
    }

    public Task SendWebPush(PushAdditionalQuestionsModel model)
    {
        return _publisher.PublishAsync(new DelayPushMessage
        {
            CompanyId = model.CompanyId,
            NotificationType = "WeNeedMoreDetails",
            TimeoutMs = 5_000,
            UserId = model.UserId,
        });
    }

    public async Task SendMobilePush(PushAdditionalQuestionsModel model)
    {
        var hasUserMobileApplication = await _pushService.HasUserMobileApplication(model.UserId);
        if (!hasUserMobileApplication) return;
        
        var title = await _localizationService.GetTermOrEnOrNullExt("push.title", model.Language);
        var text = await _localizationService.GetTermOrEnOrNullExt("push.text", model.Language);
        await _pushService.MobilePush(new MobilePushContract()
        {
            UserId = model.UserId,
            CompanyId = model.CompanyId,
            Title = title,
            Text = text,
            Payload = new MobilePushContractPayload
            {
                Type = "AdditionalQuestionsNotification"
            }
        });
    }
}


public class PushAdditionalQuestionsModel
{
    public Guid CompanyId { get; set; }
    public Guid UserId { get; set; }
    public string Language { get; set; }
}