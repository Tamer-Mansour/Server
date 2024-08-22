using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Server.Models
{
    public class Ticket
    {
        [Key]
        public int TicketId { get; set; }

        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public int StatusId { get; set; }
        [ForeignKey("StatusId")]
        public TicketStatus TicketStatus { get; set; }

        public int PriorityId { get; set; }
        [ForeignKey("PriorityId")]
        public TicketPriority TicketPriority { get; set; }

        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? ResolvedAt { get; set; }
        public DateTime? ClosedAt { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }

        public string? AssignedByUserId { get; set; }
        [ForeignKey("AssignedByUserId")]
        public User? AssignedByUser { get; set; }

        public ICollection<TicketAttachment> TicketAttachments { get; set; } = new List<TicketAttachment>();
        public ICollection<TicketCategoryAssignment> TicketCategoryAssignments { get; set; } = new List<TicketCategoryAssignment>();
        public ICollection<TicketComment> TicketComments { get; set; } = new List<TicketComment>();
        public ICollection<TicketHistory> TicketHistories { get; set; } = new List<TicketHistory>();
    }
}
