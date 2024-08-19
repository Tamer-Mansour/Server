using Server.Models;
using Server.Repositories.TicketPriorities;

namespace Server.Services.TicketPriorities
{
    public class TicketPriorityService : ITicketPriorityService
    {
        private readonly ITicketPriorityRepository _repository;

        public TicketPriorityService(ITicketPriorityRepository repository)
        {
            _repository = repository;
        }

        public async Task<TicketPriority> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<TicketPriority>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task AddAsync(TicketPriority ticketPriority)
        {
            await _repository.AddAsync(ticketPriority);
        }

        public async Task UpdateAsync(TicketPriority ticketPriority)
        {
            await _repository.UpdateAsync(ticketPriority);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
