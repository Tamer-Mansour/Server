using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Models;


namespace Server.Repositories.TicketStatuses
{
    public class TicketStatusRepository : ITicketStatusRepository
    {
        private readonly AppDbContext _context;

        public TicketStatusRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<TicketStatus> GetByIdAsync(int id)
        {
            return await _context.TicketStatuses
                .Include(s => s.Tickets) // Include related Tickets
                .FirstOrDefaultAsync(s => s.StatusId == id);
        }

        public async Task<IEnumerable<TicketStatus>> GetAllAsync()
        {
            return await _context.TicketStatuses
                .Include(s => s.Tickets) // Include related Tickets
                .ToListAsync();
        }

        public async Task AddAsync(TicketStatus ticketStatus)
        {
            await _context.TicketStatuses.AddAsync(ticketStatus);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TicketStatus ticketStatus)
        {
            _context.TicketStatuses.Update(ticketStatus);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TicketStatus ticketStatus)
        {
            _context.TicketStatuses.Remove(ticketStatus);
            await _context.SaveChangesAsync();
        }
    }
}
