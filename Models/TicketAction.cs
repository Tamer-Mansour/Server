using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Server.Models
{
    public class TicketAction
    {
        [Key]
        public int ActionId { get; set; }
        public string ActionName { get; set; } = string.Empty;

        public ICollection<TicketHistory> TicketHistories { get; set; } = new List<TicketHistory>();
    }
}
