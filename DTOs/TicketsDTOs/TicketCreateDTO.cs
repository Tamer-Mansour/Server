namespace Server.DTOs.TicketsDTOs
{
    public class TicketCreateDTO
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int StatusId { get; set; }
        public int PriorityId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string UserId { get; set; } = string.Empty;
    }
}
