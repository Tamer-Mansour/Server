using Server.Models;

namespace Server.Repositories.TicketCategoryAssignments
{
    public interface ITicketCategoryAssignmentRepository
    {
        Task<TicketCategoryAssignment> GetByIdAsync(int id);
        Task<IEnumerable<TicketCategoryAssignment>> GetAllAsync(int pageNumber, int pageSize);
        Task AddAsync(TicketCategoryAssignment ticketCategoryAssignment);
        Task<TicketCategoryAssignment> GetByTicketIdAndCategoryIdAsync(int ticketId, int categoryId);
        Task UpdateAsync(TicketCategoryAssignment ticketCategoryAssignment);
        Task DeleteAsync(TicketCategoryAssignment ticketCategoryAssignment);
        Task<int> GetCountAsync();
    }
}
