namespace Server.DTOs.TicketAttachmentsDTOs
{
    public class TicketAttachmentCreateDTO
    {
        public int TicketId { get; set; }
        public string FilePath { get; set; } = string.Empty;
        public string FileName { get; set; } = string.Empty;
        public DateTime UploadedAt { get; set; }
    }
}
