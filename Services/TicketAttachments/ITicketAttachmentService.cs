using Server.Models;

namespace Server.Services.TicketAttachments
{
    public interface ITicketAttachmentService
    {
        Task<TicketAttachment> GetByIdAsync(int id);
        Task<IEnumerable<TicketAttachment>> GetAllAsync();
        Task AddAsync(TicketAttachment ticketAttachment);
        Task UpdateAsync(TicketAttachment ticketAttachment);
        Task DeleteAsync(int id);
    }
}
