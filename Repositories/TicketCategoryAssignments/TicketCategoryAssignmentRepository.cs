using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.Models;

namespace Server.Repositories.TicketCategoryAssignments
{
    public class TicketCategoryAssignmentRepository : ITicketCategoryAssignmentRepository
    {
        private readonly AppDbContext _context;

        public TicketCategoryAssignmentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<TicketCategoryAssignment> GetByIdAsync(int id)
        {
            return await _context.TicketCategoryAssignments.FindAsync(id);
        }

        public async Task<IEnumerable<TicketCategoryAssignment>> GetAllAsync()
        {
            return await _context.TicketCategoryAssignments.ToListAsync();
        }

        public async Task AddAsync(TicketCategoryAssignment ticketCategoryAssignment)
        {
            await _context.TicketCategoryAssignments.AddAsync(ticketCategoryAssignment);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(TicketCategoryAssignment ticketCategoryAssignment)
        {
            _context.TicketCategoryAssignments.Update(ticketCategoryAssignment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var ticketCategoryAssignment = await GetByIdAsync(id);
            if (ticketCategoryAssignment != null)
            {
                _context.TicketCategoryAssignments.Remove(ticketCategoryAssignment);
                await _context.SaveChangesAsync();
            }
        }
    }
}
