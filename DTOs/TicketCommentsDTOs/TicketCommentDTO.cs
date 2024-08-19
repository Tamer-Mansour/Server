namespace Server.DTOs.TicketCommentsDTOs
{
    public class TicketCommentDTO
    {
        public int CommentId { get; set; }
        public int TicketId { get; set; }
        public string UserId { get; set; } = string.Empty;
        public string Comment { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
    }
}
