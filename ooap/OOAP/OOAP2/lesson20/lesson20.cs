using System;
using System.Collections.Generic;
using System.Security;
using System.Threading.Tasks;
using OOAP2.lesson8;

namespace OOAP2.lesson20;


//наследование вариаций, базовый класс TicketEditedNotification отправляет нотификацию об изменении тикета,
//и класс TicketEditedWithChangesNotification переопределяет логику TicketEditedNotification добавляя дополнительный текст в нотификацию со списком изменений


public interface ITelegramSender
{
    Task Send(string message);
} 
public abstract class TelegramNotification
{
    private readonly ITelegramSender _sender;

    public TelegramNotification(ITelegramSender sender)
    {
        _sender = sender;
    }

    public async Task Send()
    {
        var message = BuildMessage();
        await _sender.Send(message);
    }

    protected abstract string BuildMessage();
}

public class TicketEditedNotification : TelegramNotification
{
    private readonly Guid _ticketId;
    private readonly string _ticketName;

    public TicketEditedNotification(Guid ticketId, string ticketName, ITelegramSender sender): base(sender)
    {
        _ticketId = ticketId;
        _ticketName = ticketName;
    }

    protected override string BuildMessage()
    {
        return $"{_ticketName} edited.";
    }
}

public class TicketEditedWithChangesNotification : TicketEditedNotification
{
    private readonly List<string> _changes;

    public TicketEditedWithChangesNotification(Guid ticketId, string ticketName, List<string> changes, ITelegramSender sender): base(ticketId, ticketName, sender)
    {
        _changes = changes;
    }

    protected override string BuildMessage()
    {
        var bs = base.BuildMessage();
        return bs + " Changes list " + string.Join(" ", _changes);
    }
}

//наследование с конкретизацией, базовый класс HttpAuthorizationHandler с набором предопределенных методов через http контекст и его реализации BasicAuthAuthorizationHandler, JwtTokenAuthorizationHandler

public class AuthorizeResult
{
    public bool Success { get; init; }
}

public class HttpContext
{
    public Dictionary<string, string> Headers { get; init; } = new();
}
public abstract class HttpAuthorizationHandler
{
    public async Task<AuthorizeResult> Authorize(HttpContext context)
    {
        var res = await Check(context);
        return new AuthorizeResult
        {
            Success = res
        };
    }

    protected abstract Task<bool> Check(HttpContext context);
}

public class BasicAuthAuthorizationHandler : HttpAuthorizationHandler
{
    private readonly SecureString _userName;
    private readonly SecureString _password;

    public BasicAuthAuthorizationHandler(SecureString userName, SecureString password)
    {
        _userName = userName;
        _password = password;
    }
    protected override async Task<bool> Check(HttpContext context)
    {
        //check headers here
        return true;
    }
}

//структурное наследование, класс CompanyTotalRisk реализует интерфейс IRiskEntity, позволяющий считать риски по сущностям IRiskEntity из списка или другим образом

public enum RiskLevel
{
    High,
    Low,
    Medium
}
public interface IRiskEntity
{
    Task<RiskLevel> GetLevel();
}

public class CompanyTotalRisk : IRiskEntity
{
    private readonly Guid _companyId;

    public CompanyTotalRisk(Guid companyId)
    {
        _companyId = companyId;
    }
    public async Task<RiskLevel> GetLevel()
    {
        //calc risk here
        return RiskLevel.High;
    }
}