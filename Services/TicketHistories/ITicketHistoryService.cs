using Server.Models;

namespace Server.Services.TicketHistories
{
    public interface ITicketHistoryService
    {
        Task<TicketHistory> GetByIdAsync(int id);
        Task<IEnumerable<TicketHistory>> GetAllAsync();
        Task AddAsync(TicketHistory ticketHistory);
        Task UpdateAsync(TicketHistory ticketHistory);
        Task DeleteAsync(int id);
    }
}
