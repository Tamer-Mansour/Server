using Server.Models;

namespace Server.Repositories.TicketComments
{
    public interface ITicketCommentRepository
    {
        Task<TicketComment> GetByIdAsync(int id);
        Task<IEnumerable<TicketComment>> GetAllAsync();
        Task AddAsync(TicketComment ticketComment);
        Task UpdateAsync(TicketComment ticketComment);
        Task DeleteAsync(int id);
    }
}
