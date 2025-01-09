using h_work.lesson43.example2;
using Xunit;

namespace h_work.lesson87.Example2;

public class After
{
    public void MoveNext()
    {
        var session = new AdditionalQuestionsSessionV2(
            new AdditionalQuestionsGroup(
            [
                new AdditionalQuestionInfo(),
                new AdditionalQuestionInfo()
            ])
        );
        session.Start();

        var questions = session.Questions; 
        
        var current = questions.Current;
        
        questions.Answer(current);
        questions.MoveNext();

        var newCurrent = questions.Current;
    }
}


public class AdditionalQuestionsGroup
{
    enum QuestionStatus
    {
        Answered = 1,
        PendingAnswer = 2,
    }

    struct InternalQuestion(QuestionStatus status, AdditionalQuestionInfo value)
    {
        public QuestionStatus Status { get; } = status;
        public AdditionalQuestionInfo Value { get; } = value;
    }
    
    struct CurrentIndex
    {
        public int Index { get; }
        private CurrentIndex(int index)
        {
            Index = index;
        }

        public static CurrentIndex Start()
        {
            return new CurrentIndex(0);
        }

        public CurrentIndex MoveLeft()
        {
            var idx = Math.Max(0, Index - 1);
            return new CurrentIndex(idx);
        }
        
        public CurrentIndex MoveRight(int maxElements)
        {
            Assert.True(maxElements > 0);
            
            var idx = Math.Min(Index + 1, maxElements - 1);
            return new CurrentIndex(idx);
        }
    }
    

 
    private List<InternalQuestion> _visible = new();
    private List<AdditionalQuestionInfo> _pending = new();
    
    private CurrentIndex _currentIndex;
    public AdditionalQuestionsGroup(List<AdditionalQuestionInfo> questions)
    {
        Assert.True(questions.Count > 0);
        InitGroups(questions);
    }
    
    //tbd json constructor

    private void InitGroups(List<AdditionalQuestionInfo> questions)
    {
        _visible = questions
            .Where(c => c.IsAnswered)
            .Select( c => new InternalQuestion(QuestionStatus.Answered, c))
            .ToList();
        
        _pending = questions
            .Where(c => !c.IsAnswered)
            .ToList();

        EnsurePendingAnswerLastVisible();

        _currentIndex = CurrentIndex.Start();
    }
    
    public AdditionalQuestionInfo Current => GetCurrent().Value;
    private InternalQuestion GetCurrent() => _visible[_currentIndex.Index];

    public bool HasUnanswered() => _pending.Count > 0;
    
    public void MoveBack()
    {
        _currentIndex = _currentIndex.MoveLeft();
    }
    public void MoveNext()
    {
        _currentIndex = _currentIndex.MoveRight(_visible.Count);
    }

    public void Answer(AdditionalQuestionInfo question)
    {
        Assert.NotNull(question);
        
        var current = GetCurrent();
        if (current.Status != QuestionStatus.PendingAnswer) return;
        
        Assert.Equal(current.Value.Id, question.Id);

        _visible[_currentIndex.Index] = new InternalQuestion(QuestionStatus.Answered, new AdditionalQuestionInfo
        {
            Id = current.Value.Id,
            IsAnswered = true
        });
        
        EnsurePendingAnswerLastVisible();
    }

    private void EnsurePendingAnswerLastVisible()
    {
        if (!HasUnanswered()) return;
        if (_visible.Last().Status == QuestionStatus.PendingAnswer) return;
        
        var pending = _pending[0];
        _pending.RemoveAt(0);

        _visible.Add(new InternalQuestion(QuestionStatus.PendingAnswer, pending));
    }
}

public class AdditionalQuestionsSessionV2
{
    public AdditionalQuestionsSessionV2(AdditionalQuestionsGroup questions)
    {
        Id = Guid.NewGuid();
        Questions = questions;
        Status = EAdditionalQuestionsSessionStatus.Created;
    }
    
    //tbd json constructor

    public Guid Id { get; private set; }
    public EAdditionalQuestionsSessionStatus Status { get; private set; }
    public AdditionalQuestionsGroup Questions { get; private set; }
    
    public void Start()
    {
        Assert.Equal(Status, EAdditionalQuestionsSessionStatus.Created);
        Assert.True(Questions.HasUnanswered());

        Status = EAdditionalQuestionsSessionStatus.Started;
    }

    public void Finish()
    {
        Assert.Equal(Status, EAdditionalQuestionsSessionStatus.Started);
        Assert.False(Questions.HasUnanswered());
        
        Status = EAdditionalQuestionsSessionStatus.Finished;
    }
}