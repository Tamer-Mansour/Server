using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Models
{
    public class TicketHistory
    {
        [Key]
        public int HistoryId { get; set; }

        public int TicketId { get; set; }
        [ForeignKey("TicketId")]
        public Ticket Ticket { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }

        public int ActionId { get; set; }
        [ForeignKey("ActionId")]
        public TicketAction TicketAction { get; set; }

        public DateTime ActionDate { get; set; }
        public string Details { get; set; } = string.Empty;
    }
}
