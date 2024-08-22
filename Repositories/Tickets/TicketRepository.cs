using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Models;

namespace Server.Repositories.Tickets
{
    public class TicketRepository : ITicketRepository
    {
        private readonly AppDbContext _context;

        public TicketRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Ticket>> GetAllAsync(int pageNumber, int pageSize)
        {
            return await _context.Tickets
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }
        public async Task<int> GetCountAsync()
        {
            return await _context.Tickets.CountAsync();
        }

        public async Task<Ticket> GetByIdAsync(int id)
        {
            return await _context.Tickets.FindAsync(id);
        }

        public async Task AddAsync(Ticket ticket)
        {
            await _context.Tickets.AddAsync(ticket);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Ticket ticket)
        {
            _context.Tickets.Update(ticket);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Ticket ticket)
        {
            _context.Tickets.Remove(ticket);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Ticket>> GetByPriorityAsync(int priorityId)
        {
            return await _context.Tickets
                .Where(t => t.PriorityId == priorityId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Ticket>> GetByStatusAsync(int statusId)
        {
            return await _context.Tickets
                .Where(t => t.StatusId == statusId)
                .ToListAsync();
        }


    }
}
