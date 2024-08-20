using AutoMapper;
using Server.DTOs.Pagination;
using Server.DTOs.TicketCategoriesDTOs;
using Server.DTOs.TicketsDTOs;
using Server.Models;
using Server.Repositories.TicketCategories;

namespace Server.Services.TicketCategories
{
    public class TicketCategoryService : ITicketCategoryService
    {
        private readonly ITicketCategoryRepository _repository;
        private readonly IMapper _mapper;

        public TicketCategoryService(ITicketCategoryRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<TicketCategoryDTO> GetByIdAsync(int id)
        {
            var ticketCategory = await _repository.GetByIdAsync(id);
            return _mapper.Map<TicketCategoryDTO>(ticketCategory);
        }

        public async Task<IEnumerable<TicketCategoryDTO>> GetAllAsync()
        {
            var ticketCategories = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<TicketCategoryDTO>>(ticketCategories);
        }

        public async Task<PaginatedResult<TicketCategoryDTO>> GetPaginatedAsync(int pageNumber, int pageSize)
        {
            var ticketCategories = await _repository.GetPaginatedAsync(pageNumber, pageSize);
            var totalItems = await _repository.GetCountAsync();

            var ticketCategoryDtos = _mapper.Map<IEnumerable<TicketCategoryDTO>>(ticketCategories);

            return new PaginatedResult<TicketCategoryDTO>
            {
                Items = ticketCategoryDtos,
                TotalCount = totalItems,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        public async Task<TicketResponseDto> AddAsync(TicketCategoryCreateDTO ticketCategoryCreateDTO)
        {
            var ticketCategory = _mapper.Map<TicketCategory>(ticketCategoryCreateDTO);
            await _repository.AddAsync(ticketCategory);
            return new TicketResponseDto
            {
                IsSuccess = true,
                Message = "Ticket category created successfully",
                MessageCode = 200,
                Data = ticketCategory
            };
        }

        public async Task<TicketResponseDto> UpdateAsync(int id, TicketCategoryUpdateDTO ticketCategoryUpdateDTO)
        {
            var ticketCategory = await _repository.GetByIdAsync(id);
            if (ticketCategory == null)
            {
                return new TicketResponseDto
                {
                    IsSuccess = false,
                    Message = $"Ticket category with {id} is not found",
                    MessageCode = 404,
                };
            }
            _mapper.Map(ticketCategoryUpdateDTO, ticketCategory);
            await _repository.UpdateAsync(ticketCategory);

            return new TicketResponseDto
            {
                IsSuccess = true,
                Message = "Ticket category updated successfully",
                MessageCode = 200,
                Data = ticketCategory
            };
        }

        public async Task<TicketResponseDto> DeleteAsync(int id)
        {
            var ticketCategory = await _repository.GetByIdAsync(id);
            if (ticketCategory == null)
            {
                return new TicketResponseDto
                {
                    IsSuccess = false,
                    Message = $"Ticket category with {id} is not found",
                    MessageCode = 404,
                };
            }

            await _repository.DeleteAsync(id);
            return new TicketResponseDto
            {
                IsSuccess = true,
                Message = "Ticket category deleted successfully",
                MessageCode = 200
            };
        }
    }
}
