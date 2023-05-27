namespace h_work.lesson4.example1.After;

public class AdditionalQuestionsNotificationMessageHandler
{
    private readonly IUserInfoGetter _userInfoGetter;
    private readonly IAdditionalQuestionsPusher _pusher;
    private readonly IUnansweredAdditionalQuestionsChecker _unansweredAdditionalQuestions;

    public AdditionalQuestionsNotificationMessageHandler(
        IUserInfoGetter userInfoGetter, 
        IAdditionalQuestionsPusher pusher, IUnansweredAdditionalQuestionsChecker unansweredAdditionalQuestions)
    {
        _userInfoGetter = userInfoGetter;
        _pusher = pusher;
        _unansweredAdditionalQuestions = unansweredAdditionalQuestions;
    }
    
    public async Task HandleMessage(AdditionalQuestionsNotificationMessage message)
    {
        var userInfo = await _userInfoGetter.GetUser(message.UserId, CancellationToken.None);

        var pushModel = new PushAdditionalQuestionsModel
        {
            CompanyId = message.CompanyId,
            UserId = message.UserId,
            Language = userInfo.Language
        };
        await _pusher.SendWebPush(pushModel);
        await _pusher.SendMobilePush(pushModel);

        await _unansweredAdditionalQuestions.CheckAsync(message.UserId, message.CompanyId);
    }
}

public class AdditionalQuestionsNotificationMessage
{
    public Guid CompanyId { get; set; }
    public Guid UserId { get; set; }
}