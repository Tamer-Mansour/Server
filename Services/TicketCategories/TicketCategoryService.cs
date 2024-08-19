using Server.Models;
using Server.Repositories.TicketCategories;

namespace Server.Services.TicketCategories
{
    public class TicketCategoryService : ITicketCategoryService
    {
        private readonly ITicketCategoryRepository _repository;

        public TicketCategoryService(ITicketCategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<TicketCategory> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<TicketCategory>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task AddAsync(TicketCategory ticketCategory)
        {
            await _repository.AddAsync(ticketCategory);
        }

        public async Task UpdateAsync(TicketCategory ticketCategory)
        {
            await _repository.UpdateAsync(ticketCategory);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
