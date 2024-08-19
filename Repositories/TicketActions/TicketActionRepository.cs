using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Models;
using Server.Repositories.TicketActions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Server.Repositories.TicketActions
{
    public class TicketActionRepository : ITicketActionRepository
    {
        private readonly AppDbContext _context;

        public TicketActionRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<TicketAction> GetByIdAsync(int id)
        {
            return await _context.TicketActions.FindAsync(id);
        }

        public async Task<IEnumerable<TicketAction>> GetAllAsync()
        {
            return await _context.TicketActions.ToListAsync();
        }

        public async Task AddAsync(TicketAction ticketAction)
        {
            await _context.TicketActions.AddAsync(ticketAction);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TicketAction ticketAction)
        {
            _context.TicketActions.Update(ticketAction);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var ticketAction = await GetByIdAsync(id);
            if (ticketAction != null)
            {
                _context.TicketActions.Remove(ticketAction);
                await _context.SaveChangesAsync();
            }
        }
    }
}
