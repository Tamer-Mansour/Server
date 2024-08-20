using Server.Models;

namespace Server.Repositories.TicketCategories
{
    public interface ITicketCategoryRepository
    {
        Task<TicketCategory> GetByIdAsync(int id);
        Task<IEnumerable<TicketCategory>> GetAllAsync();
        Task AddAsync(TicketCategory ticketCategory);
        Task UpdateAsync(TicketCategory ticketCategory);
        Task DeleteAsync(int id);
        Task<IEnumerable<TicketCategory>> GetPaginatedAsync(int pageNumber, int pageSize);
        Task<int> GetCountAsync();
    }
}
