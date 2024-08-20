using System.ComponentModel.DataAnnotations;

namespace Server.DTOs.TicketPrioritiesDTOs
{
    public class TicketPriorityUpdateDTO
    {
        [Required]
        public string PriorityName { get; set; } = string.Empty;
    }
}
