namespace h_work.lesson65.example3;

public enum AdditionalQuestionsSessionStatus
{
    Started = 1,
    Finished = 2
}

public class AdditionalQuestion
{
    
}


public class AdditionalQuestionSession
{
    private List<AdditionalQuestion> _pendingQueue = new();
    public AdditionalQuestionsSessionStatus Status { get; private set; }
    
    public void Finish(bool force = false)
    {
        if (force)
        {
            Status = AdditionalQuestionsSessionStatus.Finished;
            return;
        }

        if (Status != AdditionalQuestionsSessionStatus.Started)
        {
            throw new Exception($"Unexpected session status. Can't finish session in status {Status}");
        }

        if (_pendingQueue.Any())
        {
            throw new Exception($"There is pending questions");
        }

        Status = AdditionalQuestionsSessionStatus.Finished;
    }
}