using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Models;

namespace Server.Repositories.TicketCategories
{
    public class TicketCategoryRepository : ITicketCategoryRepository
    {
        private readonly AppDbContext _context;

        public TicketCategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<TicketCategory> GetByIdAsync(int id)
        {
            return await _context.TicketCategories.FindAsync(id);
        }

        public async Task<IEnumerable<TicketCategory>> GetAllAsync()
        {
            return await _context.TicketCategories.ToListAsync();
        }

        public async Task AddAsync(TicketCategory ticketCategory)
        {
            await _context.TicketCategories.AddAsync(ticketCategory);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TicketCategory ticketCategory)
        {
            _context.TicketCategories.Update(ticketCategory);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var ticketCategory = await GetByIdAsync(id);
            if (ticketCategory != null)
            {
                _context.TicketCategories.Remove(ticketCategory);
                await _context.SaveChangesAsync();
            }
        }
    }
}
