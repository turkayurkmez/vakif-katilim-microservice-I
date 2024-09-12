namespace Server
{
    public class TicketRepository(ILogger<TicketRepository> logger)
    {
        private int availableTickets = 5;

        public int GetAvailableTickets() => availableTickets;
        public bool BuyTickets(string user, int count)
        {
            var updatedCount = availableTickets - count;
            if (updatedCount < 0 )
            {
                logger.LogError($"{user}, bilet satın alamadı. Yeterli bilet yok!");
                return false;
            }
            availableTickets = updatedCount;
            logger.LogInformation($"{user} başarıyla biletini aldı");
            return true;

        }

    }
}
