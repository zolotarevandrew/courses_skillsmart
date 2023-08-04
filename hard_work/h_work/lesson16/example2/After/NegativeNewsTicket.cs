using h_work.lesson16.example2.After.Entities;
using h_work.lesson16.example2.Before;

namespace h_work.lesson16.example2.After;

public interface IChildTicket
{
    TicketId ParentId { get; }
}

public class NegativeNewsTicket : Ticket, IChildTicket
{
    private ITicketStorage _storage;

    public NegativeNewsTicket(
        CddReviewTicket cddReviewTicket, 
        TicketId id, 
        TicketRelation relation, 
        TicketVersion version, 
        TicketAssignee author, 
        string source, 
        ITicketStorage storage) 
        : base(id, relation, version, author, source)
    {
        _storage = storage;
        ParentId = cddReviewTicket.Id;
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

    public override TicketType Type => TicketType.NegativeNews;
    
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

    public TicketId ParentId { get; }
}