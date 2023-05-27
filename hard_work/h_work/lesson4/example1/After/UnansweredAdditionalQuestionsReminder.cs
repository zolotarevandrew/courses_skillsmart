namespace h_work.lesson4.example1.After;

public interface IUnansweredAdditionalQuestionsReminder
{
    Task Remind(Guid userId);
}

public class UnansweredAdditionalQuestionsReminder : IUnansweredAdditionalQuestionsReminder
{
    private readonly IUserInfoGetter _userInfoGetter;
    private readonly IEmailNotificationService _emailNotificationService;
    private readonly ISmsNotificationService _smsNotificationService;
    private readonly AdditionalQuestionsLink _additionalQuestionsLink;
    public UnansweredAdditionalQuestionsReminder(
        IUserInfoGetter userInfoGetter, 
        IEmailNotificationService emailNotificationService, 
        ISmsNotificationService smsNotificationService, AdditionalQuestionsLink additionalQuestionsLink)
    {
        _userInfoGetter = userInfoGetter;
        _emailNotificationService = emailNotificationService;
        _smsNotificationService = smsNotificationService;
        _additionalQuestionsLink = additionalQuestionsLink;
    }
    
    public async Task Remind(Guid userId)
    {
        var userInfo = await _userInfoGetter.GetUser(userId, CancellationToken.None);
        await SendSms(userInfo);
        await SendMail(userInfo);
    }
    
    async Task SendSms(UserInfoBase user)
    {
        await _smsNotificationService.SendAdditionalQuestionsRequiredLink(
            new MobilePhone(user.PhoneCode, user.PhoneNumber),
            new SmsAnswersRequiredModel
            {
                Language = user.Language,
                Link = _additionalQuestionsLink.Get(user.Language),
            });
    }

    async Task SendMail(UserInfoBase user)
    {
        await _emailNotificationService.SendAdditionalQuestions(user.Email,
            new EmailAdditionalQuestionsModel
            {
                FullName = $"{user.FirstName} {user.LastName}",
                Lang = user.Language,
                Link = _additionalQuestionsLink.Get(user.Language),
            });
    }
}