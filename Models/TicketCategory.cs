using System.ComponentModel.DataAnnotations;

namespace Server.Models
{
    public class TicketCategory
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;

        public ICollection<TicketCategoryAssignment> TicketCategoryAssignments { get; set; } = new List<TicketCategoryAssignment>();
    }
}
