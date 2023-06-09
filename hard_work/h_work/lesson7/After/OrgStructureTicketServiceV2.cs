using h_work.lesson7.After.Visitors;

namespace h_work.lesson7.After;

public class OrgStructureTicketServiceV2 : TicketServiceV2, ITicketVisitorElement
{
    public Task Accept(ITicketVisitor visitor)
    {
        return visitor.Visit(this);
    }
}