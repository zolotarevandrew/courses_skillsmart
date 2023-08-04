using h_work.lesson16.example2.After.Entities;

namespace h_work.lesson16.example2.After;

public class Example
{
    private readonly ITicketFactory _ticketFactory;

    public Example(ITicketFactory ticketFactory)
    {
        _ticketFactory = ticketFactory;
    }
    
    public async Task WorkWithTicket(TicketId ticketId)
    {
        var ticket = await _ticketFactory.Get(ticketId);
        var context = new TicketOperationContext();
        await ticket.MarkInReview(new TicketAssignee(Guid.NewGuid(), "pablo"), context);
        await ticket.Reopen(context);
        await ticket.MarkInReview(new TicketAssignee(Guid.NewGuid(), "other guy"), context);
        await ticket.MarkReviewCompleted(context);
        await ticket.Complete(new CompleteTicketOperationContext());
    }
    
    public async Task CreateTicket()
    {
        var cddReviewTicket = new CddReviewTicket(
            new TicketId(Guid.NewGuid()),
            new TicketRelation(Guid.NewGuid()),
            new TicketVersion("1.0.0"),
            new NoneTicketAssignee(),
            "source");
        await _ticketFactory.Create(cddReviewTicket);
        
    }
}