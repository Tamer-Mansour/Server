using Server.DTOs.Pagination;
using Server.DTOs.TicketCommentsDTOs;
using Server.DTOs.TicketsDTOs;
using Server.Models;

namespace Server.Services.TicketComments
{
    public interface ITicketCommentService
    {
        Task<TicketCommentDTO> GetByIdAsync(int id);
        Task<PaginatedResult<TicketCommentDTO>> GetAllAsync(int pageNumber, int pageSize);
        Task<TicketResponseDto> AddAsync(TicketCommentCreateDTO ticketCommentCreateDTO);
        Task<TicketResponseDto> UpdateAsync(int id, TicketCommentUpdateDTO ticketCommentUpdateDTO);
        Task<TicketResponseDto> DeleteAsync(int id);
    }
}
