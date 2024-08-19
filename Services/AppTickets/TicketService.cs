using Server.Models;
using Server.Repositories.AppTickets;

namespace Server.Services.AppTickets
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _ticketRepository;

        public TicketService(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public Task<IEnumerable<Ticket>> GetAllAsync()
        {
            return _ticketRepository.GetAllAsync();
        }

        public Task<Ticket> GetByIdAsync(int id)
        {
            return _ticketRepository.GetByIdAsync(id);
        }

        public Task AddAsync(Ticket ticket)
        {
            return _ticketRepository.AddAsync(ticket);
        }

        public Task UpdateAsync(Ticket ticket)
        {
            return _ticketRepository.UpdateAsync(ticket);
        }

        public Task DeleteAsync(int id)
        {
            return _ticketRepository.DeleteAsync(id);
        }
    }
}
