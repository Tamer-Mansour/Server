using Server.Models;
using Server.Repositories;
using Server.Repositories.TicketActions;
using Server.Services.TicketActions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Server.Services.TicketActions
{
    public class TicketActionService : ITicketActionService
    {
        private readonly ITicketActionRepository _repository;

        public TicketActionService(ITicketActionRepository repository)
        {
            _repository = repository;
        }

        public async Task<TicketAction> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<TicketAction>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task AddAsync(TicketAction ticketAction)
        {
            await _repository.AddAsync(ticketAction);
        }

        public async Task UpdateAsync(TicketAction ticketAction)
        {
            await _repository.UpdateAsync(ticketAction);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
