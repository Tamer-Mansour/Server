using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Server.DTOs.Pagination;
using Server.DTOs.TicketActionsDTOs;
using Server.DTOs.TicketCategoriesDTOs;
using Server.DTOs.TicketCategoryAssignmentsDTOs;
using Server.DTOs.TicketsDTOs;
using Server.Models;
using Server.Repositories.TicketCategoryAssignments;
using Server.Utilities;

namespace Server.Services.CategoryAssignment
{
    public class TicketCategoryAssignmentService : ITicketCategoryAssignmentService
    {
        private readonly ITicketCategoryAssignmentRepository _repository;
        private readonly IMapper _mapper;

        public TicketCategoryAssignmentService(ITicketCategoryAssignmentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<TicketCategoryAssignmentDTO> GetByIdAsync(int id)
        {
            var ticketCategoryAssignment = await _repository.GetByIdAsync(id);
            return ticketCategoryAssignment != null ? _mapper
                .Map<TicketCategoryAssignmentDTO>(ticketCategoryAssignment) : null;
        }

        public async Task<PaginatedResult<TicketCategoryAssignmentDTO>> GetAllAsync(int pageNumber, int pageSize)
        {
            var ticketCategoryAssignment = await _repository.GetAllAsync(pageNumber, pageSize);
            var totalItems = await _repository.GetCountAsync();

            var ticketCategoryAssignmentDtos = _mapper.Map<IEnumerable<TicketCategoryAssignmentDTO>>(ticketCategoryAssignment);


            return new PaginatedResult<TicketCategoryAssignmentDTO>
            {
                Items = ticketCategoryAssignmentDtos,
                TotalCount = totalItems,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        public async Task<TicketResponseDto> AddAsync(TicketCategoryAssignmentCreateDTO ticketCategoryAssignmentCreateDTO)
        {
            var existingAssignment = _repository.GetByTicketIdAndCategoryIdAsync(
                ticketCategoryAssignmentCreateDTO.TicketId,
                ticketCategoryAssignmentCreateDTO.CategoryId
                );

            if (existingAssignment != null)
            {
                return new TicketResponseDto
                {
                    IsSuccess = false,
                    Message = "This ticket is already assigned to the specified category.",
                    MessageCode = 400
                };
            };

            var ticketCategoryAssignment = _mapper.Map<TicketCategoryAssignment>(ticketCategoryAssignmentCreateDTO);
            await _repository.AddAsync(ticketCategoryAssignment);
            return new TicketResponseDto
            {
                IsSuccess = true,
                Message = "Ticket category assignment created successfully",
                MessageCode = 200,
                Data = ticketCategoryAssignment
            };
        }

        public async Task<TicketResponseDto> UpdateAsync(int id, TicketCategoryAssignmentUpdateDTO ticketCategoryAssignmentUpdateDTO)
        {
            var ticketCategoryAssignment = await _repository.GetByIdAsync(id);
            if (ticketCategoryAssignment == null)
            {
                return new TicketResponseDto
                {
                    IsSuccess = false,
                    Message = $"Ticket category assignment with ID {id} could not be found.",
                    MessageCode = 404
                };
            }

            _mapper.Map(ticketCategoryAssignmentUpdateDTO, ticketCategoryAssignment);
            await _repository.UpdateAsync(ticketCategoryAssignment);

            return new TicketResponseDto
            {
                IsSuccess = true,
                Message = "Ticket category assignment updated successfully",
                MessageCode = 200,
                Data = ticketCategoryAssignment

            };
        }

        public async Task<TicketResponseDto> DeleteAsync(int id)
        {
            var ticketCategoryAssignment = await _repository.GetByIdAsync(id);

            if (ticketCategoryAssignment == null)
            {
                return new TicketResponseDto
                {
                    IsSuccess = false,
                    Message = $"Ticket category assignment with ID {id} could not be found.",
                    MessageCode = 404
                };
            }

            await _repository.DeleteAsync(ticketCategoryAssignment);

            return new TicketResponseDto
            {
                IsSuccess = true,
                Message = "Ticket category assignment deleted successfully",
                MessageCode = 200
            };
        }
    }
}
