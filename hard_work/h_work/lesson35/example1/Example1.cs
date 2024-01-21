namespace h_work.lesson35.example1;

public class Example1
{
    private readonly IAdditionalQuestionService _questionService;

    /*
     * До - сервис ответа на доп.вопросы от банка при открытии счета
     */
    public void Before()
    {
        /*
            if (User.IsCS())
            throw new CustomWebException("NotAllowed");

        var next = await _service.AnswerAndGetNextOrNull(User.Id, User.Company.Id, contract.Id,
            new QuestionAnswer
            {
                Files = contract.Files,
                Text = contract.Text
            });

        await OnQuestionAnswered(contract.Id);
         */
    }
    
    /*
    * После - производим рефакторинг
    */

    public interface IAdditionalQuestionService
    {
        Task<ActiveAdditionalQuestionSession?> ActiveSession(Guid companyId, Guid userId);
        Task<(CurrentAdditionalQuestion Question, bool NotExists)> CurrentQuestion(ActiveAdditionalQuestionSession session);
        Task Answer(CurrentAdditionalQuestion question, AdditionalQuestionAnswer answer);
        Task MoveForward(ActiveAdditionalQuestionSession session);
        Task MoveBackward(ActiveAdditionalQuestionSession session);
    }

    public class CurrentAdditionalQuestion
    {
        public Guid SessionId { get; init; }
    }

    public class ActiveAdditionalQuestionSession
    {
    }

    public class AdditionalQuestionAnswer
    {
        public List<string> Files { get; set; }
        public string Text { get; set; }
    }

    public Example1(IAdditionalQuestionService questionService)
    {
        _questionService = questionService;
    }
    
    public async Task After()
    {
        var userId = Guid.NewGuid();
        var companyId = Guid.NewGuid();
        
        var session = await _questionService.ActiveSession(companyId, userId);
        if (session == null)
        {
            throw new InvalidOperationException("No active session");
        }
        
        var currentQuestion = await _questionService.CurrentQuestion(session);
        if (currentQuestion.NotExists)
        {
            throw new InvalidOperationException("No current question");
        }
        
        var answer = new AdditionalQuestionAnswer
        {
            Files = new List<string>(),
            Text = "text"
        };
        await _questionService.Answer(currentQuestion.Question, answer);
        await _questionService.MoveForward(session);

        var nextQuestion = await _questionService.CurrentQuestion(session);
        if (nextQuestion.NotExists)
        {
            //Make logic for next question    
        }
    }
}