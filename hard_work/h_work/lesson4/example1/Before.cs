namespace h_work.lesson4.example1;

public class AdditionalQuestionsNotificationMessageHandler 
{
    private readonly IGlobalInfo _globalInfo;
    private readonly IPushService _pushService;
    private readonly IEmailNotificationService _emailService;
    private readonly ISmsNotificationService _smsNotificationService;
    private readonly ILocalizationService _localizationService;
    private readonly IUserInfoGetter _userInfoGetter;
    private readonly AdditionalQuestionsConfig _config;
    private readonly IAdditionaQuestionsDataService _data;
    private readonly IPublisher _publisher;

    public AdditionalQuestionsNotificationMessageHandler(
        IGlobalInfo globalInfo,
        IPushService pushService,
        IEmailNotificationService emailService,
        ISmsNotificationService smsNotificationService,
        ILocalizationService localizationService,
        IUserInfoGetter userInfoGetter,
        AdditionalQuestionsConfig config,
        IAdditionaQuestionsDataService data, IPublisher publisher)
    {
        _globalInfo = globalInfo;
        _pushService = pushService;
        _emailService = emailService;
        _smsNotificationService = smsNotificationService;
        _localizationService = localizationService;
        _userInfoGetter = userInfoGetter;
        _config = config;
        _data = data;
        _publisher = publisher;
    }

    public async Task HandleMessage(AdditionalQuestionsNotificationMessage message)
    {
        if (message.ReminderId is not null || message.IsReminder)
            await SendReminder(message);
        else
            await Notify(message);
    }
    
    private async Task Notify(AdditionalQuestionsNotificationMessage message)
    {
        await _publisher.PublishAsync(new DelayPushMessage
        {
            CompanyId = message.CompanyId,
            NotificationType = "WeNeedMoreDetails",
            TimeoutMs = 5_000,
            UserId = message.UserId,
        });

        bool isOnline = await _pushService.IsUserOnline(message.UserId.ToString());
        if (!isOnline && message.NotifyMobile)
        {
            var hasAppItem = await _pushService.HasUserMobileApplication(message.UserId);
            if (hasAppItem)
            {
                var user = await _userInfoGetter.GetUser(message.UserId, CancellationToken.None);
                var title = await _localizationService.GetTermOrEnOrNullExt("push.title", user.Language);
                var text = await _localizationService.GetTermOrEnOrNullExt("push.text", user.Language);
                await _pushService.MobilePush(new MobilePushContract()
                {
                    UserId = message.UserId,
                    CompanyId = message.CompanyId,
                    Title = title,
                    Text = text,
                    Payload = new MobilePushContractPayload
                    {
                        Type = "AdditionalQuestionsNotification"
                    }
                });
            }
        }
        message.ReminderId = Guid.NewGuid().ToString();
        await _data.SetActualNotificationId(message.CompanyId, message.UserId, message.ReminderId);
        
        await _publisher.SchedulePublishAsync(message, TimeSpan.FromSeconds(_config.ReminderSendInSeconds));
    }
    private async Task SendReminder(AdditionalQuestionsNotificationMessage message)
    {
        var reminderId = await _data.GetActualNotificationId(message.CompanyId, message.UserId);
        if (reminderId != message.ReminderId)
            return;

        var user = await _userInfoGetter.GetUser(message.UserId, CancellationToken.None);
        await SendMail(message, user);
        await SendSms(message, user);
    }

    async Task SendSms(AdditionalQuestionsNotificationMessage message, UserInfoBase user)
    {
        if (string.IsNullOrEmpty(user?.PhoneNumber))
            return;
        if (!message.NotifyMobile)
            return;

        await _smsNotificationService.SendAdditionalQuestionsRequiredLink(
            new MobilePhone(user.PhoneCode, user.PhoneNumber),
            new SmsAnswersRequiredModel
            {
                Language = user.Language,
                Link = QuestionsLink(user.Language),
            });
    }

    async Task SendMail(AdditionalQuestionsNotificationMessage message, UserInfoBase user)
    {
        await _emailService.SendAdditionalQuestions(user.Email,
            new EmailAdditionalQuestionsModel
            {
                FullName = $"{user.FirstName} {user.LastName}",
                Lang = user.Language,
                Link = QuestionsLink(user.Language),
            });
    }

    private string QuestionsLink(string lang)
        => _globalInfo.Domain.TrimEnd(new[] { '/' }) + $"/{(lang).ToLower()}{_config.AdditionalQuestionsUrl}";
    
}

public interface ISmsNotificationService
{
    Task SendAdditionalQuestionsRequiredLink(MobilePhone mobilePhone, SmsAnswersRequiredModel smsAnswersRequiredModel);
}

public interface IEmailNotificationService
{
    Task SendAdditionalQuestions(string userEmail, EmailAdditionalQuestionsModel emailAdditionalQuestionsModel);
}

public interface IPushService
{
    Task MobilePush(MobilePushContract mobilePushContract);
    Task<bool> HasUserMobileApplication(Guid messageUserId);
    Task<bool> IsUserOnline(string toString);
}

public class AdditionalQuestionsConfig
{
    public string AdditionalQuestionsUrl { get; set; }
    public double ReminderSendInSeconds { get; set; }
}

public interface ILocalizationService
{
    Task<object> GetTermOrEnOrNullExt(string pushTitle, object language);
}

public interface IAdditionaQuestionsDataService
{
    Task<string> GetActualNotificationId(Guid messageCompanyId, Guid messageUserId);
    Task SetActualNotificationId(Guid messageCompanyId, Guid messageUserId, string messageReminderId);

    Task<bool> IsAnswered(Guid messageCompanyId, Guid messageUserId);
    Task<bool> SetAnswered(Guid messageCompanyId, Guid messageUserId);
}

public interface IUserInfoGetter
{
    Task<UserInfoBase> GetUser(Guid messageUserId, CancellationToken none);
}

public interface IPublisher
{
    Task PublishAsync<T>(T message);
    Task SchedulePublishAsync<T>(T message, TimeSpan fromSeconds);
}

public interface IGlobalInfo
{
    string Domain { get; set; }
}

public class MobilePushContractPayload
{
    public string Type { get; set; }
}

public class DelayPushMessage
{
    public Guid CompanyId { get; set; }
    public string NotificationType { get; set; }
    public int TimeoutMs { get; set; }
    public Guid UserId { get; set; }
}

public class MobilePushContract
{
    public Guid UserId { get; set; }
    public Guid CompanyId { get; set; }
    public object Title { get; set; }
    public object Text { get; set; }
    public MobilePushContractPayload Payload { get; set; }
}

public class SmsAnswersRequiredModel
{
    public string Language { get; set; }
    public string Link { get; set; }
}

public class MobilePhone
{
    public MobilePhone(string phoneCode, string phoneNumber)
    {
        
    }
}

public class EmailAdditionalQuestionsModel
{
    public string FullName { get; set; }
    public object Lang { get; set; }
    public string Link { get; set; }
}

public class UserInfoBase
{
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string Language { get; set; }
    public string LastName { get; set; }
    public string PhoneCode { get; set; }
    public string PhoneNumber { get; set; }
}

public class AdditionalQuestionsNotificationMessage
{
    public Guid CompanyId { get; set; }
    public Guid UserId { get; set; }
    public bool NotifyMobile { get; set; }
    public string ReminderId { get; set; }
    public bool IsReminder { get; set; }
}
