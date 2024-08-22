using Server.Models;

namespace Server.Repositories.TicketHistories
{
    public interface ITicketHistoryRepository
    {
        Task<TicketHistory> GetByIdAsync(int id);
        Task<IEnumerable<TicketHistory>> GetAllAsync(int pageNumber, int pageSize);
        Task AddAsync(TicketHistory ticketHistory);
        Task UpdateAsync(TicketHistory ticketHistory);
        Task DeleteAsync(TicketHistory ticketHistory);
        Task<int> GetCountAsync();
    }
}
