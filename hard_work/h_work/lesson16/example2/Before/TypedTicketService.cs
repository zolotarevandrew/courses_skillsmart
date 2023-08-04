namespace h_work.lesson16.example2.Before;

public interface ITicketContext
{
    
}

public interface IPropertyExtractor
{
    
}

public class ExecuteViewDataOptions
{
    
}


public enum ETicketAction 
{
    None = 0,
    Done = 1 << 2,
    Approve = 1 << 4,
}

/// <summary>
/// здесь внутри в конкретной реализации использовался ITicketService, который был разман по всему коду
/// </summary>
public interface ITypedTicketService
{
    Task<bool> IsTicketTriggered(ITicketContext ticketContext, IPropertyExtractor propetyExtractor);
    Task<object> GetViewData(ITicketContext ticketContext, OperationContext operationContext);
    Task<ETicketAction> GetActions(ITicketContext ticketContext, OperationContext operationContext);
    Task ExecuteViewData(ITicketContext ticketContext, ExecuteViewDataOptions options, OperationContext operationContext);
    

    Task TicketCreating(CreateTicketOptions options, OperationContext operationContext, IPropertyExtractor propetyExtractor);
    Task<bool> CheckDataChanged(ITicketContext ticketContext, object checkData, OperationContext operationContext);

    Task CompleteTicket(ITicketContext ticketContext, IPropertyExtractor propetyExtractor, OperationContext operationContext);
    
    Task<string> GetTicketTitle(ITicketContext ticketContext);
    Task<object> GetTicketRelatedEntitiesInfo(ITicketContext ticketContext);

    Task ApplyTicketChanges(ITicketContext ticketContext, CreateTicketOptions options,
        OperationContext operationContext,
        IPropertyExtractor propetyExtractor);

}