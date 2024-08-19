using Server.Models;

namespace Server.Repositories.TicketStatuses
{
    public interface ITicketStatusRepository
    {
        Task<TicketStatus> GetByIdAsync(int id);
        Task<IEnumerable<TicketStatus>> GetAllAsync();
        Task AddAsync(TicketStatus ticketStatus);
        Task UpdateAsync(TicketStatus ticketStatus);
        Task DeleteAsync(int id);
    }
}
