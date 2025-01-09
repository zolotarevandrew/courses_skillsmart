using h_work.lesson43.example2;

namespace h_work.lesson87.Example2;

public class Before
{
    public void Usage()
    {
        var session = new AdditionalQuestionsSession();
    }
}

public class AdditionalQuestionInfo
{
    public Guid Id { get; set; }
    public bool IsAnswered { get; set; }
}

public class AdditionalQuestionsSession
{
    public Guid Id { get; private set; }
    public EAdditionalQuestionsSessionStatus Status { get; private set; }
    
    private readonly List<AdditionalQuestionInfo> _pendingQueue = new();
    private readonly List<AdditionalQuestionInfo> _answeredAllowNav = new();
    private int? _currentAnsweredQuestionIndex;

    public AdditionalQuestionInfo CurrentQuestionInfo()
    {
        if (_currentAnsweredQuestionIndex.HasValue)
        {
            //invariant
            /*if (_currentAnsweredQuestionIndex.Value > _answeredAllowNav.Count - 1)
            {
                throw new ArgumentOutOfRangeException(nameof(_currentAnsweredQuestionIndex));
            }*/

            return _answeredAllowNav.ElementAtOrDefault(_currentAnsweredQuestionIndex.Value);
        }

        var question = _pendingQueue.FirstOrDefault();
        return question;
    }

    public bool MoveBack()
    {
        if (HasPrevious())
        {
            _currentAnsweredQuestionIndex = (_currentAnsweredQuestionIndex ?? _answeredAllowNav.Count) - 1;
            return true;
        }

        return false;
    }

    public bool MoveNext()
    {
        if (!_currentAnsweredQuestionIndex.HasValue)
        {
            var current = _pendingQueue[0];
            current.IsAnswered = true;
            _answeredAllowNav.Add(current);

            _pendingQueue.RemoveAt(0);
            return _pendingQueue.Any();
        }

        if (HasNextAnswered())
        {
            _currentAnsweredQuestionIndex++;
            return true;
        }

        _currentAnsweredQuestionIndex = null;
        return _pendingQueue.Any();
    }

    public bool HasPrevious() => _answeredAllowNav.Any()
                                 && (!_currentAnsweredQuestionIndex.HasValue || _currentAnsweredQuestionIndex > 0);

    private bool HasNextAnswered() => _answeredAllowNav.Any()
                                      && _currentAnsweredQuestionIndex.HasValue
                                      && _currentAnsweredQuestionIndex < _answeredAllowNav.Count - 1;

    public void Start()
    {
        if (Status != EAdditionalQuestionsSessionStatus.Created)
        {
            throw new Exception("Session has already been started");
        }

        Status = EAdditionalQuestionsSessionStatus.Started;
    }

    public void Finish()
    {
        if (Status != EAdditionalQuestionsSessionStatus.Started)
        {
            throw new Exception($"Unexpected session status. Can't finish session in status {Status}");
        }

        if (_pendingQueue.Any())
        {
            throw new Exception($"Can't finish session. There are {_pendingQueue.Count} pending questions");
        }

        Status = EAdditionalQuestionsSessionStatus.Finished;
    }
}
