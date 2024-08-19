using Server.Models;

namespace Server.Services.TicketCategories
{
    public interface ITicketCategoryService
    {
        Task<TicketCategory> GetByIdAsync(int id);
        Task<IEnumerable<TicketCategory>> GetAllAsync();
        Task AddAsync(TicketCategory ticketCategory);
        Task UpdateAsync(TicketCategory ticketCategory);
        Task DeleteAsync(int id);
    }
}
