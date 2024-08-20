using AutoMapper;
using Server.DTOs.TicketActionsDTOs;
using Server.DTOs.TicketsDTOs;
using Server.Models;
using Server.Repositories.TicketActions;

namespace Server.Services.TicketActions
{
    public class TicketActionService : ITicketActionService
    {
        private readonly ITicketActionRepository _ticketActionRepository;
        private readonly IMapper _mapper;

        public TicketActionService(ITicketActionRepository ticketActionRepository, IMapper mapper)
        {
            _ticketActionRepository = ticketActionRepository;
            _mapper = mapper;
        }

        public async Task<TicketActionDTO> GetTicketActionByIdAsync(int id)
        {
            var ticketAction = await _ticketActionRepository.GetByIdAsync(id);
            return ticketAction != null ? _mapper.Map<TicketActionDTO>(ticketAction) : null;
        }

        public async Task<IEnumerable<TicketActionListDTO>> GetAllTicketActionsAsync()
        {
            var ticketActions = await _ticketActionRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<TicketActionListDTO>>(ticketActions);
        }

        public async Task<TicketResponseDto> AddTicketActionAsync(TicketActionCreateDTO ticketActionCreateDTO)
        {
            var ticketAction = _mapper.Map<TicketAction>(ticketActionCreateDTO);
            await _ticketActionRepository.AddAsync(ticketAction);
            return new TicketResponseDto
            {
                IsSuccess = true,
                Message = "Ticket action created successfully",
                MessageCode = 200,
                //Data = ticketAction
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

            _mapper.Map(ticketActionUpdateDTO, ticketAction);
            await _ticketActionRepository.UpdateAsync(ticketAction);

            return new TicketResponseDto
            {
                IsSuccess = true,
                Message = "Ticket action updated successfully",
                MessageCode = 200,
                //Data = ticketAction

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

            await _ticketActionRepository.DeleteAsync(ticketAction);
            return new TicketResponseDto
            {
                IsSuccess = true,
                Message = "Ticket action deleted successfully",
                MessageCode = 200
            };
        }
    }
}
