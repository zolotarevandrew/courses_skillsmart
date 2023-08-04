using h_work.lesson16.example2.After.Entities;
using h_work.lesson16.example2.Before;

namespace h_work.lesson16.example2.After;




public record TicketId(Guid Value);


public record TicketAssignee(Guid Id, string Name);

public record NoneTicketAssignee() : TicketAssignee(Guid.Empty, string.Empty);

public record TicketVersion(string Value);

public record TicketReopenedResult(bool Value);

public record TicketShortInfo(string Title);
public record TicketFullInfo(string Title, object Data);
public record TicketFullInfo<TData>(string Title, TData Dt) : TicketFullInfo(Title, (object)Dt);

public record TicketOperationContext();
public record CompleteTicketOperationContext() : TicketOperationContext;

public abstract class TypedTicket<TData> : Ticket
{
    protected TypedTicket(TicketId id, TicketRelation relation, TicketVersion version, TicketAssignee author, string source) : base(id, relation, version, author, source)
    {
    }
}

public abstract class Ticket
{
    protected abstract ITicketStorage GetStorage();
    protected TicketVersion Version { get; }
    protected TicketAssignee Assignee { get; }
    protected string Source { get; }
    
    protected Ticket(
        TicketId id, 
        TicketRelation relation, 
        TicketVersion version, 
        TicketAssignee author, 
        string source)
    {
        Id = id;
        Relation = relation;
        Version = version;
        Assignee = author;
        Source = source;
        Status = ETicketStatus.Created;
    }
    
    public abstract TicketType Type { get; }
    public TicketId Id { get; }
    public TicketRelation Relation { get; }
    public ETicketStatus Status { get; }
    
    /// <summary>
    /// предусловие, проверяем изменились ли данные
    /// </summary>
    /// постусловие, тикет изменил статус
    public async Task<TicketReopenedResult> Reopen(TicketOperationContext operationContext)
    {
        await GetStorage().ChangeStatus(Id, ETicketStatus.Reopened);
        //publish message
        return new TicketReopenedResult(true);
    }

    /// <summary>
    /// постусловие, у тикета изменился Assignee
    public async Task AssignTo(TicketAssignee assignedTo, TicketOperationContext operationContext)
    {
        await GetStorage().ChangeAssignee(Id, assignedTo.Id);
        //publish message
    }
    
    /// <summary>
    /// предусловие тикет находится в одном из финальных статусов и уже не закрыт
    /// постусловие, тикет завершен, данные изменить будет нельзя (только если переоткрыть)
    public async Task Complete(CompleteTicketOperationContext operationContext)
    {
        if (Status == ETicketStatus.Closed)
        {
            //return custom result here
            return;
        }
        if (Status != ETicketStatus.ReviewCompleted)
        {
            //return custom result here
            return;
        }
        await GetStorage().ChangeStatus(Id, ETicketStatus.Closed);
        //publish message
    }

    //переход по статусу (помечаем удаленным, не отображаем на фронтенде такие тикеты)
    public async Task MarkDeleted(TicketOperationContext operationContext)
    {
        await GetStorage().ChangeStatus(Id, ETicketStatus.Deleted);
    }

    //переход по статусу (ревью завершено)
    public async Task MarkReviewCompleted(TicketOperationContext operationContext)
    {
        await GetStorage().ChangeStatus(Id, ETicketStatus.ReviewCompleted);
    }
    
    //переход по статусу (в ревью)
    
    /// <summary>
    /// предусловие тикет был только создан
    /// постусловие у тикета изменился Assignee
    /// постусловие у тикета изменился Статус
    public async Task MarkInReview(TicketAssignee assignee, TicketOperationContext operationContext)
    {
        await GetStorage().ChangeStatus(Id, ETicketStatus.InReview);
        await AssignTo(assignee, operationContext);
    }
    
    /// <summary>
    /// получаем доступные действия по тикету
    public abstract Task<ETicketAction> GetAvailableActions(TicketOperationContext operationContext);
    /// <summary>
    //получаем короткую информацию о тикете (используем для фронта, но если нужна кастомная дто, просто делаем конвертацию в контроллерах на основе типа тикета или еще как-то)
    public abstract Task<TicketShortInfo> GetShortInfo(TicketOperationContext context);
    /// <summary>
    /// получаем полную информацию о тикете (используем для фронта, но если нужна кастомная дто, просто делаем конвертацию в контроллерах на основе типа тикета или еще как-то)
    public abstract Task<TicketFullInfo> GetFullInfo(TicketOperationContext operationContext);
    
    
}


