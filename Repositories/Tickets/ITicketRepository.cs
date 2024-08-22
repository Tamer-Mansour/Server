using Server.Models;

namespace Server.Repositories.Tickets
{
    public interface ITicketRepository
    {
        Task<IEnumerable<Ticket>> GetAllAsync(int pageNumber, int pageSize);
        Task<Ticket> GetByIdAsync(int id);
        Task AddAsync(Ticket ticket);
        Task UpdateAsync(Ticket ticket);
        Task DeleteAsync(Ticket ticket);
        Task<int> GetCountAsync();

        Task<IEnumerable<Ticket>> GetByPriorityAsync(int priorityId);
        Task<IEnumerable<Ticket>> GetByStatusAsync(int statusId);

        //Task<IEnumerable<Ticket>> GetClosedTicketsAsync();
    }
}
