using Server.Models;

namespace Server.Services.TicketComments
{
    public interface ITicketCommentService
    {
        Task<TicketComment> GetByIdAsync(int id);
        Task<IEnumerable<TicketComment>> GetAllAsync();
        Task AddAsync(TicketComment ticketComment);
        Task UpdateAsync(TicketComment ticketComment);
        Task DeleteAsync(int id);
    }
}
