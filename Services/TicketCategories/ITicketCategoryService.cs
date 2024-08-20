using Server.DTOs.Pagination;
using Server.DTOs.TicketCategoriesDTOs;
using Server.DTOs.TicketsDTOs;

namespace Server.Services.TicketCategories
{
    public interface ITicketCategoryService
    {
        Task<TicketCategoryDTO> GetByIdAsync(int id);
        Task<PaginatedResult<TicketCategoryDTO>> GetPaginatedAsync(int pageNumber, int pageSize);
        Task<TicketResponseDto> AddAsync(TicketCategoryCreateDTO ticketCategoryCreateDTO);
        Task<TicketResponseDto> UpdateAsync(int id, TicketCategoryUpdateDTO ticketCategoryUpdateDTO);
        Task<TicketResponseDto> DeleteAsync(int id);
    }
}
