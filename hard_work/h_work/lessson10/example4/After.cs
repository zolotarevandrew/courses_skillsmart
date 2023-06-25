namespace h_work.lessson10.example4;

public class TaskChangesCalculatorV2
{
    public async Task Calc()
    {
        ETicketStatus? ticketStatus = null;
        bool hasChanges = false;

        ETicketStatus? newStatus = (ticketStatus, hasChanges) switch
        {
            (ETicketStatus.InReview, true) or
                (ETicketStatus.ReviewCompleted, true) => ETicketStatus.ReadyForReview,

            (ETicketStatus.PendingCheck, true) or
                (ETicketStatus.Checking, true) or
                (ETicketStatus.CheckingApproved, true) or
                (ETicketStatus.CheckingCompleted, true) => ETicketStatus.CheckingReopened,

            (ETicketStatus.PendingCompliance, true) or
                (ETicketStatus.ComplianceReview, true) or
                (ETicketStatus.ComplianceApproved, true) or
                (ETicketStatus.ComplianceCompleted, true) => ETicketStatus.ComplianceReopened,

            (ETicketStatus.Done, true) => throw new InvalidOperationException("Done status not allowed"),


            (ETicketStatus.Deleted, _) => ETicketStatus.Created,
            _ => null,
        };
        bool isStatusChanged = ticketStatus != newStatus;
        if (isStatusChanged)
        {
            //changed logic
        }
    }
}