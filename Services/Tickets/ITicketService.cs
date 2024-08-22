using Server.DTOs.Pagination;
using Server.DTOs.TicketsDTOs;
using Server.Models;

namespace Server.Services.Tickets
{
    public interface ITicketService
    {
        Task<PaginatedResult<TicketDTO>> GetAllAsync(int pageNumber, int pageSize);
        Task<TicketDTO> GetByIdAsync(int id);
        Task<TicketResponseDto> AddAsync(TicketCreateDTO ticketCreateDTO);
        Task<TicketResponseDto> UpdateAsync(int id, TicketUpdateDTO ticketUpdateDTO);
        Task<TicketResponseDto> DeleteAsync(int id);

        Task<TicketResponseDto> GetTicketsByPriorityAsync(int priorityId);
        Task<TicketResponseDto> GetTicketsByStatusAsync(int statusId);
    }
}
