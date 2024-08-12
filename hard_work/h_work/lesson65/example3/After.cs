namespace h_work.lesson65.example3;




public record AdditionalQuestionSessionV2
{
    public AdditionalQuestionsSessionStatus Status { get; private set; }
    
    public (AdditionalQuestionSessionV2, string) Finish()
    {
        if (Status != AdditionalQuestionsSessionStatus.Started)
        {
            return (this, $"Unexpected session status. Can't finish session in status {Status}");
        }

        return (new AdditionalQuestionSessionV2 {Status = AdditionalQuestionsSessionStatus.Finished}, string.Empty);
    }
}