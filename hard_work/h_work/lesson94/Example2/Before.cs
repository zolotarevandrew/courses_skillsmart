namespace h_work.lesson94.Example2;

public class Before
{
    /*
     * private async Task<IFinomAdditionalQuestionsSession> GetSessionOrThrow(AdditionalQuestionsSessionContext context)
    {
        var session = await _additionalQuestionsDataService.GetSession(context.CompanyId, context.UserId);
        if (session == null)
        {
            throw new CustomWebException("NoQuestionsSessionFound");
        }

        if (session.Status == EAdditionalQuestionsSessionStatus.Finished)
        {
            throw new CustomWebException("NoUnansweredQuestions");
        }

        return session;
    }
     */
}