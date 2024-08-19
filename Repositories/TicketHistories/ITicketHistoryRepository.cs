using Server.Models;

namespace Server.Repositories.TicketHistories
{
    public interface ITicketHistoryRepository
    {
        Task<TicketHistory> GetByIdAsync(int id);
        Task<IEnumerable<TicketHistory>> GetAllAsync();
        Task AddAsync(TicketHistory ticketHistory);
        Task UpdateAsync(TicketHistory ticketHistory);
        Task DeleteAsync(int id);
    }
}
