using Server.DTOs.TicketPrioritiesDTOs;
using Server.DTOs.TicketsDTOs;
using Server.Models;

namespace Server.Services.TicketPriorities
{
    public interface ITicketPriorityService
    {
        Task<TicketPriorityDTO> GetByIdAsync(int id);
        Task<IEnumerable<TicketPriorityDTO>> GetAllAsync();
        Task<TicketResponseDto> AddAsync(TicketPriorityCreateDTO ticketPriorityCreateDTO);
        Task<TicketResponseDto> UpdateAsync(int id, TicketPriorityUpdateDTO ticketPriorityUpdateDTO);
        Task<TicketResponseDto> DeleteAsync(int id);
    }
}
