using h_work.lesson16.example2.After.Entities;
using h_work.lesson16.example2.Before;

namespace h_work.lesson16.example2.After;


public class CddReviewTicket : Ticket
{
    private ITicketStorage _storage;

    public CddReviewTicket(TicketId id, TicketRelation relation, TicketVersion version, TicketAssignee author, string source) 
        : base(id, relation, version, author, source)
    {
    }

    //вызываем в фабрике
    internal void SetStorage(ITicketStorage storage)
    {
        _storage = storage;
    }
    protected override ITicketStorage GetStorage()
    {
        return _storage;
    }

    public override TicketType Type => TicketType.CddReview;
    
    public override Task<ETicketAction> GetAvailableActions(TicketOperationContext operationContext)
    {
        throw new System.NotImplementedException();
    }

    public override Task<TicketShortInfo> GetShortInfo(TicketOperationContext context)
    {
        throw new System.NotImplementedException();
    }

    public override Task<TicketFullInfo> GetFullInfo(TicketOperationContext operationContext)
    {
        throw new System.NotImplementedException();
    }
}