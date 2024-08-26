namespace Server.DTOs.TicketHistoriesDTOs
{
    public class TicketHistoryDTO
    {
        public int HistoryId { get; set; }
        public int TicketId { get; set; }
        public string UserId { get; set; }
        public string UserFullName { get; set; }
        public string TicketTitle { get; set; }
        public string AssignedByUserId { get; set; }
        public string AssignedByUserFullName { get; set; } 
        public int ActionId { get; set; }
        public string ActionName { get; set; }
        public DateTime ActionDate { get; set; } = DateTime.Now;
        public string Details { get; set; } = string.Empty;
    }
}
