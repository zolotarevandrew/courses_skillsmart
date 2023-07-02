namespace h_work.lesson11.example5
{
    public class TicketsService 
    {
        private readonly TicketCryptoConfig _cryptoConfig;
        private readonly CryptoHelper _cryptoHelper;

        public async Task UpdateTicketData<T>(Guid ticketId, T ticketData)
        {
            DateTime timestamp =  DateTime.UtcNow;
            bool encrypt = _cryptoConfig.UseCrypto;
            string json = ticketData != null
                ? _cryptoHelper.Serialize(ticketData, encrypt)
                : null;
        }
    }

    internal class CryptoHelper
    {
        public string Serialize<T>(T ticketData, bool encrypt)
        {
            throw new NotImplementedException();
        }
    }

    internal class TicketCryptoConfig
    {
        public bool UseCrypto { get; set; }
    }
}
