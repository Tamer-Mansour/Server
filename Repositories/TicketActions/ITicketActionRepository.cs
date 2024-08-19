using Server.Models;

namespace Server.Repositories.TicketActions
{
    public interface ITicketActionRepository
    {
        Task<TicketAction> GetByIdAsync(int id);
        Task<IEnumerable<TicketAction>> GetAllAsync();
        Task AddAsync(TicketAction ticketAction);
        Task UpdateAsync(TicketAction ticketAction);
        Task DeleteAsync(int id);
    }
}
