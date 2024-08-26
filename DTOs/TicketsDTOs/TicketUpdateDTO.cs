namespace Server.DTOs.TicketsDTOs
{
    public class TicketUpdateDTO
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public int StatusId { get; set; }
        public int PriorityId { get; set; }

        public DateTime? UpdatedAt { get; set; } = DateTime.Now;
        public DateTime? ResolvedAt { get; set; }
        public DateTime? ClosedAt { get; set; }
        public string? AssignedByUserId { get; set; }
    }
}
