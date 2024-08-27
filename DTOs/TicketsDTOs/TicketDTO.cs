using Server.DTOs.TicketAttachmentsDTOs;

namespace Server.DTOs.TicketsDTOs
{
    public class TicketDTO
    {
        public int TicketId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int StatusId { get; set; }
        public string StatusName { get; set; } = string.Empty;
        public int PriorityId { get; set; }
        public string PriorityName { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
        public DateTime? ResolvedAt { get; set; }
        public DateTime? ClosedAt { get; set; } 
        public string UserId { get; set; }
        public string UserFullName { get; set; } = string.Empty;
        public string? AssignedByUserId { get; set; }
        public string? AssignedByUserFullName { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public string? TicketCategoryName { get; set; } = string.Empty;
        public List<TicketAttachmentDTO> Attachments { get; set; } = new List<TicketAttachmentDTO>();
    }
}
