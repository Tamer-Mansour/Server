using Server.DTOs.Pagination;
using Server.DTOs.TicketAttachmentsDTOs;
using Server.DTOs.TicketsDTOs;
using Server.Models;

namespace Server.Services.TicketAttachments
{
    public interface ITicketAttachmentService
    {
        Task<TicketAttachmentListDTO> GetTicketAttachmentByIdAsync(int id);
        Task<IEnumerable<TicketAttachmentListDTO>> GetAllTicketAttachmentAsync();
        Task<TicketResponseDto> AddTicketAttachmentAsync(TicketAttachmentCreateDTO ticketAttachmentCreateDTO);
        Task<TicketResponseDto> UpdateTicketAttachmentAsync(int id, TicketAttachmentUpdateDTO ticketAttachmentUpdateDTO);
        Task<TicketResponseDto> DeleteTicketAttachmentAsync(int id);
        Task<PaginatedResult<TicketAttachmentListDTO>> GetPaginatedTicketAttachmentsAsync(int pageNumber, int pageSize);

    }
}
