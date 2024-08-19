using Server.DTOs.TicketActionsDTOs;
using Server.DTOs.TicketsDTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Server.Services.TicketActions
{
    public interface ITicketActionService
    {
        Task<TicketActionDTO> GetTicketActionByIdAsync(int id);
        Task<IEnumerable<TicketActionListDTO>> GetAllTicketActionsAsync();
        Task<TicketResponseDto> AddTicketActionAsync(TicketActionCreateDTO ticketActionCreateDTO);
        Task<TicketResponseDto> UpdateTicketActionAsync(int id, TicketActionUpdateDTO ticketActionUpdateDTO);
        Task<TicketResponseDto> DeleteTicketActionAsync(int id);
    }
}
