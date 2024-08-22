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

        public async Task<IEnumerable<TicketHistory>> GetAllAsync(int pageNumber, int pageSize)
        {
            return await _context.TicketHistories
                .Include(h => h.Ticket)
                .Include(h => h.User)
                .Include(h => h.TicketAction)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
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

        public async Task DeleteAsync(TicketHistory ticketHistory)
        {
            _context.TicketHistories.Remove(ticketHistory);
            await _context.SaveChangesAsync();
        }
        public async Task<int> GetCountAsync()
        {
            return await _context.TicketHistories.CountAsync();
        }
    }
}
