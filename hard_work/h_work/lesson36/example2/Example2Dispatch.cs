using h_work.lesson16.example2.Before;

namespace h_work.lesson36;

public interface ITicketContext
{
    
}

public class OperationContext
{
    
}

public class FileItem
{
    
}
public interface IWithDocumentsTicket
{
    public Task SaveDocuments(ITicketContext ticketContext, List<FileItem> contract, OperationContext operationContext)
    {
        //default implementation in here
        return Task.CompletedTask;
    }
}

public interface IWithRiskTickets
{
    public Task CalcRisk(ITicketContext ticketContext, OperationContext operationContext)
    {
        //default implementation in here
        return Task.CompletedTask;
    }
}

public class SuggestedRisk
{
    
}

public class SuggestedRiskRequest
{
    
}

public interface IWithSuggestedRiskTickets
{
    public Task<SuggestedRisk> CalcSuggestedRisk(ITicketContext ticketContext, SuggestedRiskRequest request,
        OperationContext operationContext)
    {
        //default implementation in here
        return Task.FromResult(new SuggestedRisk());
    }
}

//базовые реализации основных налепленных методов здесь
public abstract class BaseTypedTicketService : ITypedTicketService 
{
    public Task<bool> IsTicketTriggered(lesson16.example2.Before.ITicketContext ticketContext, IPropertyExtractor propetyExtractor)
    {
        throw new NotImplementedException();
    }

    public Task<object> GetViewData(lesson16.example2.Before.ITicketContext ticketContext, lesson16.example2.Before.OperationContext operationContext)
    {
        throw new NotImplementedException();
    }

    public Task<ETicketAction> GetActions(lesson16.example2.Before.ITicketContext ticketContext, lesson16.example2.Before.OperationContext operationContext)
    {
        throw new NotImplementedException();
    }

    public Task ExecuteViewData(lesson16.example2.Before.ITicketContext ticketContext, ExecuteViewDataOptions options, lesson16.example2.Before.OperationContext operationContext)
    {
        throw new NotImplementedException();
    }

    public Task TicketCreating(CreateTicketOptions options, lesson16.example2.Before.OperationContext operationContext,
        IPropertyExtractor propetyExtractor)
    {
        throw new NotImplementedException();
    }

    public Task<bool> CheckDataChanged(lesson16.example2.Before.ITicketContext ticketContext, object checkData, lesson16.example2.Before.OperationContext operationContext)
    {
        throw new NotImplementedException();
    }

    public Task CompleteTicket(lesson16.example2.Before.ITicketContext ticketContext, IPropertyExtractor propetyExtractor,
        lesson16.example2.Before.OperationContext operationContext)
    {
        throw new NotImplementedException();
    }

    public Task<string> GetTicketTitle(lesson16.example2.Before.ITicketContext ticketContext)
    {
        throw new NotImplementedException();
    }

    public Task<object> GetTicketRelatedEntitiesInfo(lesson16.example2.Before.ITicketContext ticketContext)
    {
        throw new NotImplementedException();
    }

    public Task ApplyTicketChanges(lesson16.example2.Before.ITicketContext ticketContext, CreateTicketOptions options, lesson16.example2.Before.OperationContext operationContext,
        IPropertyExtractor propetyExtractor)
    {
        throw new NotImplementedException();
    }
}

public class MyTicket : BaseTypedTicketService, IWithSuggestedRiskTickets
{
    
}