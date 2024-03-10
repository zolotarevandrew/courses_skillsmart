namespace h_work.lesson43.example2;

public enum EAdditionalQuestionsSessionStatus
{
    Created,
    Started,
    Finished
}

public class AdditionalQuestionsSessionState
{
    public Guid Id { get; set; }
    public EAdditionalQuestionsSessionStatus Status { get; set; }
}

public class AdditionalQuestionInfo
{
    public Guid Id { get; set; }
    public EQuestionType Type { get; set; }
    public bool IsAnswered { get; set; }
}

public class EQuestionType
{
    
}

public interface IFinomAdditionalQuestionsSessionOld
{
    Guid Id { get; }
    EAdditionalQuestionsSessionStatus Status { get; }

    /// <summary>
    /// Creates internal state to persist
    /// </summary>
    /// <returns>A new copy of internal state</returns>
    AdditionalQuestionsSessionState GetInternalState();

    IReadOnlyList<AdditionalQuestionInfo> AllQuestions();
    IReadOnlyList<EQuestionType> GetQuestionTypes();
    bool HasSimpleQuestions();
    bool HasAnsweredQuestionsOfType(EQuestionType type);
    AdditionalQuestionInfo CurrentQuestionInfo();
    bool MoveBack();
    bool MoveNext();
    bool HasNext();
    bool HasPrevious();

    /// <summary>
    /// Adds new questions to a session, skips questions which are already in a session
    /// </summary>
    /// <param name="session">Current questions session</param>
    /// <param name="questions">Questions from dossier to add</param>
    /// <returns>Returns question id's and types of added questions</returns>
    List<AdditionalQuestionInfo> AddQuestions(IEnumerable<AdditionalQuestionInfo> questions);

    bool TrySetCurrentAnsweredQuestion(Guid? questionId);
    void Start();
    void Finish();
}

public interface IFinomAdditionalQuestionsSessionV2
{
    AdditionalQuestionsSessionStateV2 State { get; }

    List<AdditionalQuestionInfo> AddQuestions(IEnumerable<AdditionalQuestionInfo> questions);

    void Start();
    void Finish();
}

public class AdditionalQuestionsSessionStateV2
{
    public Guid Id { get; set; }
    public EAdditionalQuestionsSessionStatus Status { get; init; }

    public bool MoveBack()
    {
        throw new NotImplementedException();
    }

    public bool MoveNext()
    {
        throw new NotImplementedException();
    }
}