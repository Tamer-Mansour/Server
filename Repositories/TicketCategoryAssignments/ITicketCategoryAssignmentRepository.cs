using Server.Models;

namespace Server.Repositories.TicketCategoryAssignments
{
    public interface ITicketCategoryAssignmentRepository
    {
        Task<TicketCategoryAssignment> GetByIdAsync(int id);
        Task<IEnumerable<TicketCategoryAssignment>> GetAllAsync();
        Task AddAsync(TicketCategoryAssignment ticketCategoryAssignment);
        Task UpdateAsync(TicketCategoryAssignment ticketCategoryAssignment);
        Task DeleteAsync(int id);
    }
}
