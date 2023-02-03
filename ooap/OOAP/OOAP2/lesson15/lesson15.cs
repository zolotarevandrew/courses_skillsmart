using System;

namespace OOAP2.lesson15;


public enum TicketFromType
{
    User = 1,
    ExternalService = 2
}

public class TicketV1
{
    public Guid Id { get; init; }
    public TicketFromType From { get; init; }
    public string UserName { get; init; }
    public string ExternalServiceName { get; init; }
}

public class TicketV2
{
    public Guid Id { get; init; }
}


public class UserTicket : TicketV2
{
    public string UserName { get; init; }
}

public class ExternalServiceTicket : TicketV2
{
    public string ExternalServiceName { get; init; }
}

// вместо if (ticket.From == TicketFromType.User 
// используем типизированные тикеты UserTicket, ExternalServiceTicket, в БД это может храниться как модель TicketV1, но эта модель будет преобразована в зависимости от типа