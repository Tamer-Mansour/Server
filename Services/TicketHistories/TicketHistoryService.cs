using Server.Models;
using Server.Repositories.TicketHistories;

namespace Server.Services.TicketHistories
{
    public class TicketHistoryService : ITicketHistoryService
    {
        private readonly ITicketHistoryRepository _repository;

        public TicketHistoryService(ITicketHistoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<TicketHistory> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<TicketHistory>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task AddAsync(TicketHistory ticketHistory)
        {
            await _repository.AddAsync(ticketHistory);
        }

        public async Task UpdateAsync(TicketHistory ticketHistory)
        {
            await _repository.UpdateAsync(ticketHistory);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
