using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Models;

namespace Server.Repositories.TicketPriorities
{
    public class TicketPriorityRepository : ITicketPriorityRepository
    {
        private readonly AppDbContext _context;

        public TicketPriorityRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<TicketPriority> GetByIdAsync(int id)
        {
            return await _context.TicketPriorities
                .Include(p => p.Tickets) // Include related Tickets
                .FirstOrDefaultAsync(p => p.PriorityId == id);
        }

        public async Task<IEnumerable<TicketPriority>> GetAllAsync()
        {
            return await _context.TicketPriorities
                .Include(p => p.Tickets) // Include related Tickets
                .ToListAsync();
        }

        public async Task AddAsync(TicketPriority ticketPriority)
        {
            await _context.TicketPriorities.AddAsync(ticketPriority);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TicketPriority ticketPriority)
        {
            _context.TicketPriorities.Update(ticketPriority);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TicketPriority ticketPriority)
        {
            _context.TicketPriorities.Remove(ticketPriority);
            await _context.SaveChangesAsync();
        }
    }
}
