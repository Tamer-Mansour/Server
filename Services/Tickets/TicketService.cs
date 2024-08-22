using AutoMapper;
using Server.DTOs.Pagination;
using Server.DTOs.TicketsDTOs;
using Server.Models;
using Server.Repositories.Tickets;

namespace Server.Services.Tickets
{
    public class TicketService : ITicketService
    {
        private readonly ITicketRepository _repository;
        private readonly IMapper _mapper;

        public TicketService(ITicketRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<PaginatedResult<TicketDTO>> GetAllAsync(int pageNumber, int pageSize)
        {
            var tickets = await _repository.GetAllAsync(pageNumber, pageSize);
            var totalItems = await _repository.GetCountAsync();

            var ticketDtos = _mapper.Map<IEnumerable<TicketDTO>>(tickets);
            return new PaginatedResult<TicketDTO>
            {
                Items = ticketDtos,
                TotalCount = totalItems,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        public async Task<TicketDTO> GetByIdAsync(int id)
        {
            var ticket = await _repository.GetByIdAsync(id);
            return ticket != null ? _mapper.Map<TicketDTO>(ticket) : null;
        }

        public async Task<TicketResponseDto> AddAsync(TicketCreateDTO ticketCreateDTO, string? assignedByUserId = null)
        {
            var ticket = _mapper.Map<Ticket>(ticketCreateDTO);
            ticket.AssignedByUserId = assignedByUserId; // Set the user who assigned the ticket
            await _repository.AddAsync(ticket);

            return new TicketResponseDto
            {
                IsSuccess = true,
                Message = "Ticket created successfully",
                MessageCode = 200,
                Data = _mapper.Map<TicketDTO>(ticket)
            };
        }

        public async Task<TicketResponseDto> UpdateCustomerAsync(int id, TicketUpdateCustomerDTO ticketUpdateCustomerDTO)
        {
            var ticket = await _repository.GetByIdAsync(id);
            if (ticket == null)
            {
                return new TicketResponseDto
                {
                    IsSuccess = false,
                    Message = $"Ticket with ID {id} could not be found.",
                    MessageCode = 404
                };
            }

            _mapper.Map(ticketUpdateCustomerDTO, ticket);
            await _repository.UpdateAsync(ticket);

            return new TicketResponseDto
            {
                IsSuccess = true,
                Message = "Ticket updated successfully",
                MessageCode = 200,
                Data = _mapper.Map<TicketDTO>(ticket)
            };
        }

        public async Task<TicketResponseDto> UpdateSupportAsync(int id, TicketUpdateSupportDTO ticketUpdateSupportDTO)
        {
            var ticket = await _repository.GetByIdAsync(id);
            if (ticket == null)
            {
                return new TicketResponseDto
                {
                    IsSuccess = false,
                    Message = $"Ticket with ID {id} could not be found.",
                    MessageCode = 404
                };
            }

            _mapper.Map(ticketUpdateSupportDTO, ticket);
            await _repository.UpdateAsync(ticket);

            return new TicketResponseDto
            {
                IsSuccess = true,
                Message = "Ticket updated successfully",
                MessageCode = 200,
                Data = _mapper.Map<TicketDTO>(ticket)
            };
        }

        public async Task<TicketResponseDto> DeleteAsync(int id)
        {
            var ticket = await _repository.GetByIdAsync(id);
            if (ticket == null)
            {
                return new TicketResponseDto
                {
                    IsSuccess = false,
                    Message = $"Ticket with ID {id} could not be found.",
                    MessageCode = 404
                };
            }

            await _repository.DeleteAsync(ticket);
            return new TicketResponseDto
            {
                IsSuccess = true,
                Message = "Ticket deleted successfully",
                MessageCode = 200
            };
        }

        public async Task<TicketResponseDto> GetTicketsByPriorityAsync(int priorityId)
        {
            var tickets = await _repository.GetByPriorityAsync(priorityId);
            if (tickets == null || !tickets.Any())
            {
                return new TicketResponseDto
                {
                    IsSuccess = false,
                    Message = "No tickets found with the specified priority.",
                    MessageCode = 404
                };
            }

            var ticketDtos = _mapper.Map<IEnumerable<TicketDTO>>(tickets);
            return new TicketResponseDto
            {
                IsSuccess = true,
                Message = "Tickets retrieved successfully",
                MessageCode = 200,
                Data = ticketDtos
            };
        }

        public async Task<TicketResponseDto> GetTicketsByStatusAsync(int statusId)
        {
            var tickets = await _repository.GetByStatusAsync(statusId);
            if (tickets == null || !tickets.Any())
            {
                return new TicketResponseDto
                {
                    IsSuccess = false,
                    Message = "No tickets found with the specified status.",
                    MessageCode = 404
                };
            }

            var ticketDtos = _mapper.Map<IEnumerable<TicketDTO>>(tickets);
            return new TicketResponseDto
            {
                IsSuccess = true,
                Message = "Tickets retrieved successfully",
                MessageCode = 200,
                Data = ticketDtos
            };
        }

        public async Task<IEnumerable<TicketDTO>> GetTicketsByUserAsync(string userId)
        {
            var tickets = await _repository.GetTicketsByUserAsync(userId);
            return _mapper.Map<IEnumerable<TicketDTO>>(tickets);
        }

        public async Task<IEnumerable<TicketDTO>> GetTicketsAssignedToUserAsync(string userId)
        {
            var tickets = await _repository.GetTicketsAssignedToUserAsync(userId);
            return _mapper.Map<IEnumerable<TicketDTO>>(tickets);
        }
    }
}
