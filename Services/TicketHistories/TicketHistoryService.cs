using AutoMapper;
using Server.DTOs.Pagination;
using Server.DTOs.TicketHistoriesDTOs;
using Server.DTOs.TicketsDTOs;
using Server.Models;
using Server.Repositories.TicketHistories;

namespace Server.Services.TicketHistories
{
    public class TicketHistoryService : ITicketHistoryService
    {
        private readonly ITicketHistoryRepository _repository;
        private readonly IMapper _mapper;

        public TicketHistoryService(ITicketHistoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<TicketHistoryDTO> GetByIdAsync(int id)
        {
            var ticketHistory = await _repository.GetByIdAsync(id);
            return ticketHistory != null ? _mapper.Map<TicketHistoryDTO>(ticketHistory) : null;
        }

        public async Task<PaginatedResult<TicketHistoryDTO>> GetAllAsync(int pageNumber, int pageSize)
        {
            var ticketHistory = await _repository.GetAllAsync(pageNumber, pageSize);
            var totalItems = await _repository.GetCountAsync();
            var ticketHistoryDtos = _mapper.Map<IEnumerable<TicketHistoryDTO>>(ticketHistory);

            return new PaginatedResult<TicketHistoryDTO>
            {
                Items = ticketHistoryDtos,
                TotalCount = totalItems,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }


        public async Task<TicketResponseDto> AddAsync(TicketHistoryCreateDTO ticketHistoryCreateDTO)
        {
            var ticketHistory = _mapper.Map<TicketHistory>(ticketHistoryCreateDTO);
            await _repository.AddAsync(ticketHistory);
            return new TicketResponseDto
            {
                IsSuccess = true,
                Message = "Ticket comment created successfully",
                MessageCode = 200,
                Data = ticketHistory

            };
        }

        public async Task<TicketResponseDto> UpdateAsync(int id, TicketHistoryUpdateDTO ticketHistoryUpdateDTO)
        {
            var ticketHistory = await _repository.GetByIdAsync(id);
            if (ticketHistory == null)
            {
                return new TicketResponseDto
                {
                    IsSuccess = false,
                    Message = $"Ticket history with ID {id} could not be found.",
                    MessageCode = 404,
                };
            }
            _mapper.Map(ticketHistoryUpdateDTO, ticketHistory);
            await _repository.UpdateAsync(ticketHistory);
            return new TicketResponseDto
            {
                IsSuccess = true,
                Message = "Ticket history updated successfully",
                MessageCode = 200,
                Data = ticketHistory
            };
        }

        public async Task<TicketResponseDto> DeleteAsync(int id)
        {
            var ticketHistory = await _repository.GetByIdAsync(id);
            if (ticketHistory == null)
            {
                return new TicketResponseDto
                {
                    IsSuccess = false,
                    Message = $"Ticket history with ID {id} could not be found.",
                    MessageCode = 404,
                };
            }
            await _repository.DeleteAsync(ticketHistory);
            return new TicketResponseDto
            {
                IsSuccess = true,
                Message = "Ticket history deleted successfully",
                MessageCode = 200,
                Data = ticketHistory
            };
        }
    }
}
