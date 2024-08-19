using Server.Models;

namespace Server.Services.CategoryAssignment
{
    public interface ITicketCategoryAssignmentService
    {
        Task<TicketCategoryAssignment> GetByIdAsync(int id);
        Task<IEnumerable<TicketCategoryAssignment>> GetAllAsync();
        Task AddAsync(TicketCategoryAssignment ticketCategoryAssignment);
        Task UpdateAsync(TicketCategoryAssignment ticketCategoryAssignment);
        Task DeleteAsync(int id);
    }
}
