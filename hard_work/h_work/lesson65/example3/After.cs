namespace h_work.lesson65.example3;




public record AdditionalQuestionSessionV2
{
    private List<AdditionalQuestion> _pendingQueue = new();
    
    public AdditionalQuestionsSessionStatus Status { get; private set; }
    
    public (AdditionalQuestionSessionV2?, string) Finish()
    {
        if (Status != AdditionalQuestionsSessionStatus.Started)
        {
            return (null, $"Unexpected session status. Can't finish session in status {Status}");
        }
        
        if (_pendingQueue.Any())
        {
            return (null, $"There is pending questions");
        }

        return (new AdditionalQuestionSessionV2 {Status = AdditionalQuestionsSessionStatus.Finished}, string.Empty);
    }
}