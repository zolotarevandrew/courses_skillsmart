namespace h_work.lesson16.example2.Before;

public class Ticket
{
    
}

public class OperationContext
{
    
}

public class CreateTicketOptions
{
    
}

public class UserIdentity
{
    
}

public class CreateTicketNoteOptions
{
    
}

public enum ETicketGroup
{
    
}

public class ChangeTicketStatusRequest
{
    
}

public class TicketWithData<T>
{
    
}

public class TicketNote
{
    
}


public interface ITicketsService
{
    //часть методов размазана между ITypedTicketService и здесь..
    
    Task<Guid> CreateTicket(CreateTicketOptions options, OperationContext operationContext);
    
    Task ChangeTicketStatus(ChangeTicketStatusRequest request);
    Task AssignTicketTo(Guid ticketId, UserIdentity assignedTo, OperationContext operationContext);
    
    //can use just storage service
    Task UpdateTicketData<T>(Guid ticketId, T ticketData, OperationContext operationContext);
    Task UpdateTicketData<T>(Guid ticketId, OperationContext operationContext) where T : new();
    Task UpdateTicketProperty<T>(Guid ticketId, string prop, Func<T, T> action, OperationContext operationContext);
    
    Task CompleteTicket(Guid ticketId, OperationContext operationContext);
    Task<Guid> CreateTicketNote(CreateTicketNoteOptions options, OperationContext operationContext);

    //All get methods for search
    Task<Ticket> GetTicket(Guid ticketId);
    Task<List<Ticket>> GetTicketsByEntity(string entityId);
    Task<List<Ticket>> GetTicketsByParent(Guid ticketParentId);
    Task<List<Ticket>> GetTicketsByGroupKey(string groupKey, ETicketGroup? ticketGroup = null);

    Task<TicketWithData<T>> GetTicket<T>(Guid ticketId);
    Task<List<TicketWithData<T>>> GetTicketsByEntity<T>(string entityId);
    Task<List<TicketWithData<T>>> GetTicketsByGroupKey<T>(string groupKey, params ETicketGroup[] ticketGroups);
    Task<T> GetTicketData<T>(Guid ticketId);

    Task<TicketNote> GetNote(Guid noteId);
    Task<List<TicketNote>> GetNotesByTicket(Guid ticketId);
    Task<bool> HasTriggeredTasks(Guid companyId);
    Task<bool> HasOnlySanctionsTasks(Guid companyId);
    Task<bool> HasCddReviewTask(Guid companyId);
    
    Task<T> GetTicketProp<T>(Guid ticketId, string propName);
    Task<T> GetSimpleTicketProp<T>(Guid ticketId, string propName);
}