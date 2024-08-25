using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Models;

namespace Server.Repositories.TicketComments
{
    public class TicketCommentRepository : ITicketCommentRepository
    {
        private readonly AppDbContext _context;

        public TicketCommentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<TicketComment> GetByIdAsync(int id)
        {
            return await _context.TicketComments.FindAsync(id);
        }

        public async Task<IEnumerable<TicketComment>> GetAllAsync(int pageNumber, int pageSize)
        {
            return await _context.TicketComments
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task AddAsync(TicketComment ticketComment)
        {
            await _context.TicketComments.AddAsync(ticketComment);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TicketComment ticketComment)
        {
            _context.TicketComments.Update(ticketComment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TicketComment ticketComment)
        {
            _context.TicketComments.Remove(ticketComment);
            await _context.SaveChangesAsync();
        }

        public async Task<int> GetCountAsync()
        {
            return await _context.TicketComments.CountAsync();
        }
        public async Task<IEnumerable<TicketComment>> GetByTicketIdAsync(int ticketId)
        {
            return await _context.TicketComments
               .Include(c => c.User)
               .Where(c => c.TicketId == ticketId)
               .ToListAsync();
        }
    }

}
