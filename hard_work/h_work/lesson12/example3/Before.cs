namespace h_work.lesson12.example3;

public class Before
{
    public async Task CreateTicketRelay(CreateTicketRelayOptions options)
    {
        if (string.IsNullOrWhiteSpace(options.RelayId))
        {
            throw new Exception(@"RelayId can't be empty");
        }

        DateTime timestamp = DateTime.UtcNow;

        TicketRelay entity = new()
        {
            RelayId = options.RelayId,
            TicketId = options.TicketId
        };
        
        //other stuff
    }
}

public class TicketRelay
{
    public string RelayId { get; set; }
    public Guid TicketId { get; set; }
}

public class CreateTicketRelayOptions
{
    public string? RelayId { get; set; }
    public Guid TicketId { get; set; }
}