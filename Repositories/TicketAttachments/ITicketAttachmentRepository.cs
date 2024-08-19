using Server.Models;

namespace Server.Repositories.TicketAttachments
{
    public interface ITicketAttachmentRepository
    {
        Task<TicketAttachment> GetByIdAsync(int id);
        Task<IEnumerable<TicketAttachment>> GetAllAsync();
        Task AddAsync(TicketAttachment ticketAttachment);
        Task UpdateAsync(TicketAttachment ticketAttachment);
        Task DeleteAsync(int id);
    }
}
