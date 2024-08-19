using Server.Models;
using Server.Repositories.TicketCategoryAssignments;

namespace Server.Services.CategoryAssignment
{
    public class TicketCategoryAssignmentService : ITicketCategoryAssignmentService
    {
        private readonly ITicketCategoryAssignmentRepository _repository;

        public TicketCategoryAssignmentService(ITicketCategoryAssignmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<TicketCategoryAssignment> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<TicketCategoryAssignment>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task AddAsync(TicketCategoryAssignment ticketCategoryAssignment)
        {
            await _repository.AddAsync(ticketCategoryAssignment);
        }

        public async Task UpdateAsync(TicketCategoryAssignment ticketCategoryAssignment)
        {
            await _repository.UpdateAsync(ticketCategoryAssignment);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
