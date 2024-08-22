using Server.Models;

namespace Server.Repositories.TicketComments
{
    public interface ITicketCommentRepository
    {
        Task<TicketComment> GetByIdAsync(int id);
        Task<IEnumerable<TicketComment>> GetAllAsync(int pageNumber, int pageSize);
        Task AddAsync(TicketComment ticketComment);
        Task UpdateAsync(TicketComment ticketComment);
        Task DeleteAsync(TicketComment ticketComment);
        Task<int> GetCountAsync();
    }
}
