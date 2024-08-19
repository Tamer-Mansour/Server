using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Server.Models
{
    public class TicketPriority
    {
        [Key]
        public int PriorityId { get; set; }
        public string PriorityName { get; set; } = string.Empty;
        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}
