namespace h_work.lesson36;

/*
 * public interface ITypedTicketService
    {
        Task<bool> IsTicketTriggered(ITicketContext ticketContext, IPropertyExtractor propetyExtractor);

        Task<object> GetViewData(ITicketContext ticketContext, OperationContext operationContext);

        Task<ETicketAction> GetActions(ITicketContext ticketContext, OperationContext operationContext);

        Task ExecuteViewData(ITicketContext ticketContext, ExecuteViewDataOptions options, OperationContext operationContext);

        Task<TicketCreatingResult> TicketCreating(CreateTicketOptions options, OperationContext operationContext, IPropertyExtractor propetyExtractor);

        Task<List<RelayInfo>> GetRelaysInfo(IPropertyExtractor propetyExtractor);

        Task TicketCreated(CreateTicketOptions options, TicketCreatingResult ticketCreatingResult,
            OperationContext operationContext, IPropertyExtractor propetyExtractor);

        Task<bool> CheckDataChanged(ITicketContext ticketContext, object checkData, OperationContext operationContext);

        Task CompleteTicket(ITicketContext ticketContext, IPropertyExtractor propetyExtractor, OperationContext operationContext);

        Task<string> GetTicketTitle(ITicketContext ticketContext);
        Task<object> GetTicketRelatedEntitiesInfo(ITicketContext ticketContext);
        Task<TicketRelatedInfo> GetTicketRelatedInfo(ITicketContext ticketContext);

        Task ApplyTicketChanges(ITicketContext ticketContext, CreateTicketOptions options,
            TicketCreatingResult ticketCreatingResult, OperationContext operationContext,
            IPropertyExtractor propetyExtractor);

        Task<CanSkipFourEyeCheckResponse> CanSkipFourEyeCheck(IPropertyExtractor propertyExtractor);
    }
    
    public abstract class BaseTypedTicketService : ITypedTicketService 
    {
    }
    
     public abstract class BaseCddCheckTypedTicketService : BaseTypedTicketService,
        ICddCheckTypedService, ICalcRiskTicketService, ICalcSuggestedRiskTicketService 
        {
        
            //здесь 500 или 600 строчек не стал вставлять
        }
        
*/