namespace h_work.lesson4.example1.After;

public interface IUnansweredAdditionalQuestionsChecker
{
    Task CheckAsync(Guid userId, Guid companyId);
}
public class UnansweredAdditionalQuestionsChecker : IUnansweredAdditionalQuestionsChecker
{
    private readonly AdditionalQuestionsConfig _config;
    private readonly IPublisher _publisher;
    private readonly IAdditionaQuestionsDataService _additionaQuestionsData;
    public UnansweredAdditionalQuestionsChecker(
        AdditionalQuestionsConfig config, 
        IPublisher publisher, IAdditionaQuestionsDataService additionaQuestionsData)
    {
        _config = config;
        _publisher = publisher;
        _additionaQuestionsData = additionaQuestionsData;
    }
    
    public async Task CheckAsync(Guid userId, Guid companyId)
    {
        var isAnswered = await _additionaQuestionsData.IsAnswered(userId, companyId);
        if (isAnswered) return;
        
        await _publisher.SchedulePublishAsync(new CheckUnansweredAdditionalQuestionsMessage
        {
            UserId = userId,
            CompanyId = companyId
        }, TimeSpan.FromSeconds(_config.ReminderSendInSeconds));
    }
}

public class CheckUnansweredAdditionalQuestionsMessageHandler
{
    private readonly IPublisher _publisher;
    private readonly IAdditionaQuestionsDataService _additionaQuestionsData;
    private readonly IUnansweredAdditionalQuestionsReminder _questionsReminder;
    private readonly AdditionalQuestionsConfig _config;

    public CheckUnansweredAdditionalQuestionsMessageHandler(
        IUnansweredAdditionalQuestionsReminder questionsReminder, 
        IAdditionaQuestionsDataService additionaQuestionsData, 
        IPublisher publisher, AdditionalQuestionsConfig config)
    {
        _questionsReminder = questionsReminder;
        _additionaQuestionsData = additionaQuestionsData;
        _publisher = publisher;
        _config = config;
    }

    public async Task CheckAsync(CheckUnansweredAdditionalQuestionsMessage message)
    {
        var isAnswered = await _additionaQuestionsData.IsAnswered(message.CompanyId, message.UserId);
        if (isAnswered) return;
        
        await _questionsReminder.Remind(message.UserId);
        await _publisher.SchedulePublishAsync(message, TimeSpan.FromSeconds(_config.ReminderSendInSeconds));
    }
}

public class CheckUnansweredAdditionalQuestionsMessage
{
    public Guid CompanyId { get; set; }
    public Guid UserId { get; set; }
}