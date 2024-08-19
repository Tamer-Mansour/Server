using Server.Models;

namespace Server.Services.TicketStatuses
{
    public interface ITicketStatusService
    {
        Task<TicketStatus> GetByIdAsync(int id);
        Task<IEnumerable<TicketStatus>> GetAllAsync();
        Task AddAsync(TicketStatus ticketStatus);
        Task UpdateAsync(TicketStatus ticketStatus);
        Task DeleteAsync(int id);
    }
}
