using Server.Models;
using Server.Repositories.TicketAttachments;

namespace Server.Services.TicketAttachments
{
    public class TicketAttachmentService : ITicketAttachmentService
    {
        private readonly ITicketAttachmentRepository _repository;

        public TicketAttachmentService(ITicketAttachmentRepository repository)
        {
            _repository = repository;
        }

        public async Task<TicketAttachment> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<TicketAttachment>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task AddAsync(TicketAttachment ticketAttachment)
        {
            await _repository.AddAsync(ticketAttachment);
        }

        public async Task UpdateAsync(TicketAttachment ticketAttachment)
        {
            await _repository.UpdateAsync(ticketAttachment);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
