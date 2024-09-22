using h_work.lesson13.example1;

namespace h_work.lesson71.Example2;

public interface ICorporateAnalyticsSender
{
    Task ClientPushedToSales(Guid companyId, Guid userId, string trigger);
    Task SendComplexClientAssigned(Guid companyId, Guid userId, string reason, bool? isComplexClient, List<bool> complexClientsArr, bool premiumLane);
}

public interface IUboAnalyticsSender
{
    Task SendUboQuestionnaireShown(Guid companyId, Guid userId);
    Task SendUboQuestionnaireAnswered(Guid companyId, Guid userId, object eventParams = null);
    Task SendOwnershipStructureChartRequested(Guid companyId, Guid userId);
    Task SendOwnershipStructureChartSubmitted(Guid companyId, Guid userId);
}

public class UboAnalyticsSender : IUboAnalyticsSender
{
    private readonly IPublisher _publisher;

    public UboAnalyticsSender(IPublisher publisher) => _publisher = publisher;

    public async Task SendUboQuestionnaireShown(Guid companyId, Guid userId)
    {
        /*await _publisher.PublishAsync(new ObaAnalyticsMessage
        {
            EventType = "OBA: UBO Questionnaire Shown",
            UserId = userId,
            CompanyId = companyId,
        });*/
        await Task.CompletedTask;
    }

    public Task SendUboQuestionnaireAnswered(Guid companyId, Guid userId, object eventParams = null)
    {
        throw new NotImplementedException();
    }

    public Task SendOwnershipStructureChartRequested(Guid companyId, Guid userId)
    {
        throw new NotImplementedException();
    }

    public Task SendOwnershipStructureChartSubmitted(Guid companyId, Guid userId)
    {
        throw new NotImplementedException();
    }
}

/*
 * пример вызова
 * await _uboAnalyticsSender.SendOwnershipStructureConfirmed(context.CompanyId, context.UserId, shareholdersCount, companiesCount, uboCount);
*/