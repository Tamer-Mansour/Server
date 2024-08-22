using Server.DTOs.Pagination;
using Server.DTOs.TicketCategoryAssignmentsDTOs;
using Server.DTOs.TicketsDTOs;
using Server.Models;

namespace Server.Services.CategoryAssignment
{
    public interface ITicketCategoryAssignmentService
    {
        Task<TicketCategoryAssignmentDTO> GetByIdAsync(int id);
        Task<PaginatedResult<TicketCategoryAssignmentDTO>> GetAllAsync(int pageNumber, int pageSize);
        Task<TicketResponseDto> AddAsync(TicketCategoryAssignmentCreateDTO ticketCategoryAssignmentCreateDTO);
        Task<TicketResponseDto> UpdateAsync(int id, TicketCategoryAssignmentUpdateDTO ticketCategoryAssignmentUpdateDTO);
        Task<TicketResponseDto> DeleteAsync(int id);
    }
}
