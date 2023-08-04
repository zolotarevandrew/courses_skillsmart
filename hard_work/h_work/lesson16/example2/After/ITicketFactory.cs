using h_work.lesson16.example2.After.Entities;

namespace h_work.lesson16.example2.After;

public interface ITicketFactory
{
    Task<Ticket> Get(TicketId id);
    Task Create(Ticket ticket);
}

public interface ITicketStorage
{
    Task ChangeStatus(TicketId id, ETicketStatus status);
    Task ChangeAssignee(TicketId id, Guid assigneeId);
    
    Task Save(Ticket ticket);
}

