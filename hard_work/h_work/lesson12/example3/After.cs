namespace h_work.lesson12.example3;


public record CreateTicketRelayOptionsV2(string RelayId, Guid TicketId);

public class After
{
    public async Task CreateTicketRelay(CreateTicketRelayOptionsV2 options)
    {
        DateTime timestamp = DateTime.UtcNow;

        TicketRelay entity = new()
        {
            RelayId = options.RelayId,
            TicketId = options.TicketId
        };
        
        //other stuff
    }
}