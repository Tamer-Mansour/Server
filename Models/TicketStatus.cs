using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Server.Models
{
    public class TicketStatus
    {
        [Key]
        public int StatusId { get; set; }
        public string StatusName { get; set; } = string.Empty;
        public ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}
