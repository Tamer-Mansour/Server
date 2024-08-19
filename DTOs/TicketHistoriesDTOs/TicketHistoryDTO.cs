namespace Server.DTOs.TicketHistoriesDTOs
{
    public class TicketHistoryDTO
    {
        public int HistoryId { get; set; }
        public int TicketId { get; set; }
        public string UserId { get; set; }
        public int ActionId { get; set; }
        public DateTime ActionDate { get; set; }
        public string Details { get; set; } = string.Empty;
    }
}
