namespace Server.DTOs.TicketsDTOs
{
    public class TicketUpdateCustomerDTO
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int StatusId { get; set; }
        public int PriorityId { get; set; }
    }
}
