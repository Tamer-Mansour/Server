using AutoMapper;
using Server.DTOs.TicketCommentsDTOs;
using Server.DTOs.TicketsDTOs;
using Server.DTOs.TicketStatusesDTOs;
using Server.Models;
using Server.Repositories.TicketStatuses;

namespace Server.Services.TicketStatuses
{
    public class TicketStatusService : ITicketStatusService
    {
        private readonly ITicketStatusRepository _repository;
        private readonly IMapper _mapper;

        public TicketStatusService(ITicketStatusRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<TicketStatusDTO> GetByIdAsync(int id)
        {
            var ticketStatus = await _repository.GetByIdAsync(id);
            return ticketStatus != null ? _mapper.Map<TicketStatusDTO>(ticketStatus) : null;
        }

        public async Task<IEnumerable<TicketStatusDTO>> GetAllAsync()
        {
            var ticketStatus = await _repository.GetAllAsync();
            return  _mapper.Map<IEnumerable<TicketStatusDTO>>(ticketStatus);
        }

        public async Task<TicketResponseDto> AddAsync(TicketStatusCreateDTO ticketStatusCreateDTO)
        {
            var ticketStatus = _mapper.Map<TicketStatus>(ticketStatusCreateDTO);
            await _repository.AddAsync(ticketStatus);

            return new TicketResponseDto
            {
                IsSuccess = true,
                Message = "Ticket status created successfully",
                MessageCode = 200,
                Data = ticketStatus

            };
        }

        public async Task<TicketResponseDto> UpdateAsync(int id, TicketStatusUpdateDTO ticketStatusUpdateDTO)
        {
            var ticketStatus = await _repository.GetByIdAsync(id);
            if (ticketStatus == null)
            {
                return new TicketResponseDto
                {
                    IsSuccess = false,
                    Message = $"Ticket status with ID {id} could not be found.",
                    MessageCode = 404,
                };
            }
            _mapper.Map(ticketStatusUpdateDTO, ticketStatus);
            await _repository.UpdateAsync(ticketStatus);
            return new TicketResponseDto
            {
                IsSuccess = true,
                Message = "Ticket status updated successfully",
                MessageCode = 200,
                Data = ticketStatus
            };
        }

        public async Task<TicketResponseDto> DeleteAsync(int id)
        {
            var ticketStatus = await _repository.GetByIdAsync(id);
            if (ticketStatus == null)
            {
                return new TicketResponseDto
                {
                    IsSuccess = false,
                    Message = $"Ticket status with ID {id} could not be found.",
                    MessageCode = 404,
                };
            }
            await _repository.DeleteAsync(ticketStatus);
            return new TicketResponseDto
            {
                IsSuccess = true,
                Message = "Ticket status deleted successfully",
                MessageCode = 200,
            };
        }
    }
}
