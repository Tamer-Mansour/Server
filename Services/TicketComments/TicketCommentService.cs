using Server.Models;
using Server.Repositories.TicketComments;

namespace Server.Services.TicketComments
{
    public class TicketCommentService : ITicketCommentService
    {
        private readonly ITicketCommentRepository _repository;

        public TicketCommentService(ITicketCommentRepository repository)
        {
            _repository = repository;
        }

        public async Task<TicketComment> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<TicketComment>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task AddAsync(TicketComment ticketComment)
        {
            await _repository.AddAsync(ticketComment);
        }

        public async Task UpdateAsync(TicketComment ticketComment)
        {
            await _repository.UpdateAsync(ticketComment);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
