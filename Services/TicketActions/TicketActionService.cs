using Server.DTOs.TicketActionsDTOs;
using Server.DTOs.TicketsDTOs;
using Server.Models;
using Server.Repositories.TicketActions;


namespace Server.Services.TicketActions
{
    public class TicketActionService : ITicketActionService
    {
        private readonly ITicketActionRepository _ticketActionRepository;

        public TicketActionService(ITicketActionRepository ticketActionRepository)
        {
            _ticketActionRepository = ticketActionRepository;
        }

        public async Task<TicketActionDTO> GetTicketActionByIdAsync(int id)
        {
            var ticketAction = await _ticketActionRepository.GetByIdAsync(id);
            if (ticketAction == null)
            {
                return null;
            }

            return new TicketActionDTO
            {
                ActionId = ticketAction.ActionId,
                ActionName = ticketAction.ActionName
            };
        }

        public async Task<IEnumerable<TicketActionListDTO>> GetAllTicketActionsAsync()
        {
            var ticketActions = await _ticketActionRepository.GetAllAsync();
            return ticketActions.Select(ticketAction => new TicketActionListDTO
            {
                ActionId = ticketAction.ActionId,
                ActionName = ticketAction.ActionName
            }).ToList();
        }

        public async Task<TicketResponseDto> AddTicketActionAsync(TicketActionCreateDTO ticketActionCreateDTO)
        {
            var ticketAction = new TicketAction
            {
                ActionName = ticketActionCreateDTO.ActionName
            };

            await _ticketActionRepository.AddAsync(ticketAction);
            return new TicketResponseDto
            {
                IsSuccess = true,
                Message = "Ticket action created successfully",
                MessageCode = 200
            };
        }

        public async Task<TicketResponseDto> UpdateTicketActionAsync(int id, TicketActionUpdateDTO ticketActionUpdateDTO)
        {
            var ticketAction = await _ticketActionRepository.GetByIdAsync(id);
            if (ticketAction == null)
            {
                return new TicketResponseDto
                {
                    IsSuccess = false,
                    Message = $"Ticket action with ID {id} could not be found.",
                    MessageCode = 404
                };
            }

            if (ticketAction.ActionName == ticketActionUpdateDTO.ActionName)
            {
                return new TicketResponseDto
                {
                    IsSuccess = false,
                    Message = "No changes detected. The action name is already the same.",
                    MessageCode = 400
                };
            }

            ticketAction.ActionName = ticketActionUpdateDTO.ActionName;
            await _ticketActionRepository.UpdateAsync(ticketAction);

            return new TicketResponseDto
            {
                IsSuccess = true,
                Message = "Ticket action updated successfully",
                MessageCode = 200
            };
        }

        public async Task<TicketResponseDto> DeleteTicketActionAsync(int id)
        {
            var ticketAction = await _ticketActionRepository.GetByIdAsync(id);
            if (ticketAction == null)
            {
                return new TicketResponseDto
                {
                    IsSuccess = false,
                    Message = $"Ticket action with ID {id} could not be found.",
                    MessageCode = 404
                };
            }

            await _ticketActionRepository.DeleteAsync(id);
            return new TicketResponseDto
            {
                IsSuccess = true,
                Message = "Ticket action deleted successfully",
                MessageCode = 200
            };
        }
    }
}
