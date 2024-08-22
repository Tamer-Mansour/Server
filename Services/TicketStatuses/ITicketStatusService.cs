using Server.DTOs.TicketsDTOs;
using Server.DTOs.TicketStatusesDTOs;
using Server.Models;

namespace Server.Services.TicketStatuses
{
    public interface ITicketStatusService
    {
        Task<TicketStatusDTO> GetByIdAsync(int id);
        Task<IEnumerable<TicketStatusDTO>> GetAllAsync();
        Task<TicketResponseDto> AddAsync(TicketStatusCreateDTO ticketStatusCreateDTO);
        Task<TicketResponseDto> UpdateAsync(int id, TicketStatusUpdateDTO ticketStatusUpdateDTO);
        Task<TicketResponseDto> DeleteAsync(int id);
    }
}
