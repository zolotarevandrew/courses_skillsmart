namespace h_work.lesson94.Example2;


public record AdditionalQuestionsSessionContext(Guid CompanyId, Guid UserId);

public enum AdditionalQuestionSessionStatus
{
    
}

public interface IAdditionalQuestionSessionService
{
    Task<ActiveAdditionalQuestionsSession?> Active(Guid companyId, Guid userId);
}

public class ActiveAdditionalQuestionsSession()
{
    
}

public class AdditionalQuestionService(IAdditionalQuestionSessionService additionalQuestionSessionService)
{
    private async Task<ActiveAdditionalQuestionsSession?> GetActiveSession(AdditionalQuestionsSessionContext context)
    {
        return await additionalQuestionSessionService.Active(context.CompanyId, context.UserId);
    }   
}