namespace h_work.lesson7.After.Visitors;

public interface ITicketVisitor
{
    Task Visit(CompanyTicketServiceV2 companyTicket);
    Task Visit(OrgStructureTicketServiceV2 orgStructureTicket);
}

public interface ITicketVisitorElement
{
    Task Accept(ITicketVisitor visitor);
}