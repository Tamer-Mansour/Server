using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Models;

namespace Server.Repositories.TicketAttachments
{
    public class TicketAttachmentRepository : ITicketAttachmentRepository
    {
        private readonly AppDbContext _context;

        public TicketAttachmentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<TicketAttachment> GetByIdAsync(int id)
        {
            return await _context.TicketAttachments.FindAsync(id);
        }

        public async Task<IEnumerable<TicketAttachment>> GetAllAsync()
        {
            return await _context.TicketAttachments.ToListAsync();
        }

        public async Task AddAsync(TicketAttachment ticketAttachment)
        {
            await _context.TicketAttachments.AddAsync(ticketAttachment);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TicketAttachment ticketAttachment)
        {
            _context.TicketAttachments.Update(ticketAttachment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var ticketAttachment = await GetByIdAsync(id);
            if (ticketAttachment != null)
            {
                _context.TicketAttachments.Remove(ticketAttachment);
                await _context.SaveChangesAsync();
            }
        }
    }
}
