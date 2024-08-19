using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Models
{
    public class TicketCategoryAssignment
    {
        [Key]
        public int AssignmentId { get; set; }

        public int TicketId { get; set; }
        [ForeignKey("TicketId")]
        public Ticket Ticket { get; set; }

        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public TicketCategory TicketCategory { get; set; }
    }
}
