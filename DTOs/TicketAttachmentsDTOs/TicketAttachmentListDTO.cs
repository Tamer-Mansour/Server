namespace Server.DTOs.TicketAttachmentsDTOs
{
    public class TicketAttachmentListDTO
    {
        public int AttachmentId { get; set; }
        public int TicketId { get; set; }
        public string FilePath { get; set; } = string.Empty;
        public string FileName { get; set; } = string.Empty;
        public DateTime UploadedAt { get; set; }
    }
}
