using AutoMapper;
using Server.DTOs.TicketPrioritiesDTOs;
using Server.DTOs.TicketsDTOs;
using Server.Models;
using Server.Repositories.TicketPriorities;

namespace Server.Services.TicketPriorities
{
    public class TicketPriorityService : ITicketPriorityService
    {
        private readonly ITicketPriorityRepository _repository;
        private readonly IMapper _mapper;

        public TicketPriorityService(ITicketPriorityRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<TicketPriorityDTO> GetByIdAsync(int id)
        {
            var ticketPriority = await _repository.GetByIdAsync(id);
            return ticketPriority != null ? _mapper.Map<TicketPriorityDTO>(ticketPriority) : null;
        }
        public async Task<IEnumerable<TicketPriorityDTO>> GetAllAsync()
        {
            var ticketPriorities = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<TicketPriorityDTO>>(ticketPriorities);
        }

        public async Task<TicketResponseDto> AddAsync(TicketPriorityCreateDTO ticketPriorityCreateDTO)
        {
            var ticketPriority = _mapper.Map<TicketPriority>(ticketPriorityCreateDTO);
            await _repository.AddAsync(ticketPriority);
            return new TicketResponseDto
            {
                IsSuccess = true,
                Message = "Ticket priority created successfully",
                MessageCode = 200,
                Data = ticketPriority

            };

        }

        public async Task<TicketResponseDto> UpdateAsync(int id, TicketPriorityUpdateDTO ticketPriorityUpdateDTO)
        {
            var ticketPriority = await _repository.GetByIdAsync(id);
            if (ticketPriority != null)
            {
                return new TicketResponseDto
                {
                    IsSuccess = false,
                    Message = $"Ticket priority with ID {id} could not be found.",
                    MessageCode = 404,
                };
            }
            _mapper.Map(ticketPriorityUpdateDTO, ticketPriority);
            return new TicketResponseDto
            {
                IsSuccess = true,
                Message = "Ticket comment updated successfully",
                MessageCode = 200,
                Data = ticketPriority
            };
        }

        public async Task<TicketResponseDto> DeleteAsync(int id)
        {
            var ticketPriority = await _repository.GetByIdAsync(id);
            if (ticketPriority == null)
            {
                return new TicketResponseDto
                {
                    IsSuccess = false,
                    Message = $"Ticket priority with ID {id} could not be found.",
                    MessageCode = 404,
                };
            }

            await _repository.DeleteAsync(ticketPriority);

            return new TicketResponseDto
            {
                IsSuccess = true,
                Message = "Ticket priority deleted successfully",
                MessageCode = 200,
            };
        }
    }
}
