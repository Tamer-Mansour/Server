using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Models;

namespace Server.Repositories.TicketHistories
{
    public class TicketHistoryRepository : ITicketHistoryRepository
    {
        private readonly AppDbContext _context;

        public TicketHistoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<TicketHistory> GetByIdAsync(int id)
        {
            return await _context.TicketHistories
                .Include(h => h.Ticket)
                .Include(h => h.User)
                .Include(h => h.TicketAction)
                .FirstOrDefaultAsync(h => h.HistoryId == id);
        }

        public async Task<IEnumerable<TicketHistory>> GetAllAsync()
        {
            return await _context.TicketHistories
                .Include(h => h.Ticket)
                .Include(h => h.User)
                .Include(h => h.TicketAction) 
                .ToListAsync();
        }

        public async Task AddAsync(TicketHistory ticketHistory)
        {
            await _context.TicketHistories.AddAsync(ticketHistory);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TicketHistory ticketHistory)
        {
            _context.TicketHistories.Update(ticketHistory);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var ticketHistory = await GetByIdAsync(id);
            if (ticketHistory != null)
            {
                _context.TicketHistories.Remove(ticketHistory);
                await _context.SaveChangesAsync();
            }
        }
    }
}
