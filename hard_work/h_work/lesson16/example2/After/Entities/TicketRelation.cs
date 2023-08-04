namespace h_work.lesson16.example2.After.Entities;

public class TicketRelation
{
    public Guid EntityId { get; protected set; }
    public Guid CompanyId { get; protected set; }

    public TicketRelation(Guid companyId)
    {
        CompanyId = companyId;
        EntityId = companyId;
    }
    
    public TicketRelation(Guid companyId, Guid entityId)
    {
        CompanyId = companyId;
        EntityId = entityId;
    }
}