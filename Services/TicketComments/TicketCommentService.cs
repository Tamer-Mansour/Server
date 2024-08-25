using AutoMapper;
using Server.DTOs.Pagination;
using Server.DTOs.TicketCommentsDTOs;
using Server.DTOs.TicketsDTOs;
using Server.Models;
using Server.Repositories.TicketComments;

namespace Server.Services.TicketComments
{
    public class TicketCommentService : ITicketCommentService
    {
        private readonly ITicketCommentRepository _repository;
        private readonly IMapper _mapper;

        public TicketCommentService(ITicketCommentRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<TicketCommentDTO> GetByIdAsync(int id)
        {
            var ticketComment = await _repository.GetByIdAsync(id);
            return ticketComment != null ? _mapper.Map<TicketCommentDTO>(ticketComment) : null;
        }
        public async Task<IEnumerable<TicketCommentDTO>> GetByTicketIdAsync(int ticketId)
        {
            var comments = await _repository.GetByTicketIdAsync(ticketId);
            return comments != null
                ? _mapper.Map<IEnumerable<TicketCommentDTO>>(comments)
                : Enumerable.Empty<TicketCommentDTO>();
        }

        public async Task<PaginatedResult<TicketCommentDTO>> GetAllAsync(int pageNumber, int pageSize)
        {
            var ticketComment = await _repository.GetAllAsync(pageNumber, pageSize);
            var totalItems = await _repository.GetCountAsync();
            var ticketCommentDtos = _mapper.Map<IEnumerable<TicketCommentDTO>>(ticketComment);
            return new PaginatedResult<TicketCommentDTO>
            {
                Items = ticketCommentDtos,
                TotalCount = totalItems,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        public async Task<TicketResponseDto> AddAsync(TicketCommentCreateDTO ticketCommentCreateDTO)
        {
            var ticketComment = _mapper.Map<TicketComment>(ticketCommentCreateDTO);
            await _repository.AddAsync(ticketComment);

            return new TicketResponseDto
            {
                IsSuccess = true,
                Message = "Ticket comment created successfully",
                MessageCode = 200,
                Data = ticketComment
                
            };
        }

        public async Task<TicketResponseDto> UpdateAsync(int id, TicketCommentUpdateDTO ticketCommentUpdateDTO)
        {
            var ticketComment = await _repository.GetByIdAsync(id);
            if (ticketComment == null)
            {
                return new TicketResponseDto
                {
                    IsSuccess = false,
                    Message = $"Ticket comment with ID {id} could not be found.",
                    MessageCode = 404,
                };
            }
            _mapper.Map(ticketCommentUpdateDTO, ticketComment);
            await _repository.UpdateAsync(ticketComment);
            return new TicketResponseDto
            {
                IsSuccess = true,
                Message = "Ticket comment updated successfully",
                MessageCode = 200,
                Data = ticketComment
            };
        }

        public async Task<TicketResponseDto> DeleteAsync(int id)
        {
            var ticketComment = await _repository.GetByIdAsync(id);
            if (ticketComment == null)
            {
                return new TicketResponseDto
                {
                    IsSuccess = false,
                    Message = $"Ticket comment with ID {id} could not be found.",
                    MessageCode = 404,
                };
            }
            await _repository.DeleteAsync(ticketComment);
            return new TicketResponseDto
            {
                IsSuccess = true,
                Message = "Ticket comment deleted successfully",
                MessageCode = 200,
            };
        }
       
    }
}
