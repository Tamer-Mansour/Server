using Server.Models;

namespace Server.Services.TicketPriorities
{
    public interface ITicketPriorityService
    {
        Task<TicketPriority> GetByIdAsync(int id);
        Task<IEnumerable<TicketPriority>> GetAllAsync();
        Task AddAsync(TicketPriority ticketPriority);
        Task UpdateAsync(TicketPriority ticketPriority);
        Task DeleteAsync(int id);
    }
}
