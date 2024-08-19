using Server.Models;
using Server.Repositories.TicketStatuses;

namespace Server.Services.TicketStatuses
{
    public class TicketStatusService : ITicketStatusService
    {
        private readonly ITicketStatusRepository _repository;

        public TicketStatusService(ITicketStatusRepository repository)
        {
            _repository = repository;
        }

        public async Task<TicketStatus> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<TicketStatus>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task AddAsync(TicketStatus ticketStatus)
        {
            await _repository.AddAsync(ticketStatus);
        }

        public async Task UpdateAsync(TicketStatus ticketStatus)
        {
            await _repository.UpdateAsync(ticketStatus);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
