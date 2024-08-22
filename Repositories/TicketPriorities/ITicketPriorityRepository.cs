using Server.Models;

namespace Server.Repositories.TicketPriorities
{
    public interface ITicketPriorityRepository
    {
        Task<TicketPriority> GetByIdAsync(int id);
        Task<IEnumerable<TicketPriority>> GetAllAsync();
        Task AddAsync(TicketPriority ticketPriority);
        Task UpdateAsync(TicketPriority ticketPriority);
        Task DeleteAsync(TicketPriority ticketPriority);
    }
}
