using Server.DTOs.Pagination;
using Server.DTOs.TicketHistoriesDTOs;
using Server.DTOs.TicketsDTOs;
using Server.Models;

namespace Server.Services.TicketHistories
{
    public interface ITicketHistoryService
    {
        Task<TicketHistoryDTO> GetByIdAsync(int id);
        Task<PaginatedResult<TicketHistoryDTO>> GetAllAsync(int pageNumber, int pageSize);
        Task<TicketResponseDto> AddAsync(TicketHistoryCreateDTO ticketHistoryCreateDTO);
        Task<TicketResponseDto> UpdateAsync(int id, TicketHistoryUpdateDTO ticketHistoryUpdateDTO);
        Task<TicketResponseDto> DeleteAsync(int id);
    }
}
