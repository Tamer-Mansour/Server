using Server.Models;

namespace Server.Services.TicketActions
{
    public interface ITicketActionService
    {
        Task<TicketAction> GetByIdAsync(int id);
        Task<IEnumerable<TicketAction>> GetAllAsync();
        Task AddAsync(TicketAction ticketAction);
        Task UpdateAsync(TicketAction ticketAction);
        Task DeleteAsync(int id);
    }
}
