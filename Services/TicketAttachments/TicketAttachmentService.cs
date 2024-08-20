using AutoMapper;
using Server.DTOs.Pagination;
using Server.DTOs.TicketAttachmentsDTOs;
using Server.DTOs.TicketsDTOs;
using Server.Models;
using Server.Repositories.TicketAttachments;


namespace Server.Services.TicketAttachments
{
    public class TicketAttachmentService : ITicketAttachmentService
    {
        private readonly ITicketAttachmentRepository _ticketAttachmentRepository;
        private readonly IMapper _mapper;

        public TicketAttachmentService(ITicketAttachmentRepository ticketAttachmentRepository, IMapper mapper)
        {
            _ticketAttachmentRepository = ticketAttachmentRepository;
            _mapper = mapper;
        }

        public async Task<TicketAttachmentListDTO> GetTicketAttachmentByIdAsync(int id)
        {
            var ticketAttachment = await _ticketAttachmentRepository.GetByIdAsync(id);
            return ticketAttachment != null ? _mapper.Map<TicketAttachmentListDTO>(ticketAttachment) : null;
        }

        public async Task<IEnumerable<TicketAttachmentListDTO>> GetAllTicketAttachmentAsync()
        {
            var ticketAttachments = await _ticketAttachmentRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<TicketAttachmentListDTO>>(ticketAttachments);
        }

        public async Task<TicketResponseDto> AddTicketAttachmentAsync(TicketAttachmentCreateDTO ticketAttachmentCreateDTO)
        {
            var ticketAttachment = _mapper.Map<TicketAttachment>(ticketAttachmentCreateDTO);
            await _ticketAttachmentRepository.AddAsync(ticketAttachment);
            return new TicketResponseDto
            {
                IsSuccess = true,
                Message = "Ticket attachment created successfully",
                MessageCode = 200,
                Data = ticketAttachment
            };
        }

        public async Task<TicketResponseDto> UpdateTicketAttachmentAsync(int id, TicketAttachmentUpdateDTO ticketAttachmentUpdateDTO)
        {
            var ticketAttachment = await _ticketAttachmentRepository.GetByIdAsync(id);
            if (ticketAttachment == null)
            {
                return new TicketResponseDto
                {
                    IsSuccess = false,
                    Message = $"Ticket attachment with ID {id} could not be found.",
                    MessageCode = 404
                };
            }

            _mapper.Map(ticketAttachmentUpdateDTO, ticketAttachment);
            await _ticketAttachmentRepository.UpdateAsync(ticketAttachment);

            return new TicketResponseDto
            {
                IsSuccess = true,
                Message = "Ticket attachment updated successfully",
                MessageCode = 200,
                Data = ticketAttachment
            };
        }

        public async Task<PaginatedResult<TicketAttachmentListDTO>> GetPaginatedTicketAttachmentsAsync(int pageNumber, int pageSize)
        {
            var ticketAttachments = await _ticketAttachmentRepository.GetPaginatedAsync(pageNumber, pageSize);
            var totalItems = await _ticketAttachmentRepository.GetCountAsync();

            var ticketAttachmentDtos = _mapper.Map<IEnumerable<TicketAttachmentListDTO>>(ticketAttachments);

            return new PaginatedResult<TicketAttachmentListDTO>
            {
                Items = ticketAttachmentDtos,
                TotalCount = totalItems,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }


        public async Task<TicketResponseDto> DeleteTicketAttachmentAsync(int id)
        {
            var ticketAttachment = await _ticketAttachmentRepository.GetByIdAsync(id);
            if (ticketAttachment == null)
            {
                return new TicketResponseDto
                {
                    IsSuccess = false,
                    Message = $"Ticket attachment with ID {id} could not be found.",
                    MessageCode = 404
                };
            }

            await _ticketAttachmentRepository.DeleteAsync(ticketAttachment);
            return new TicketResponseDto
            {
                IsSuccess = true,
                Message = "Ticket attachment deleted successfully",
                MessageCode = 200
            };
        }
    }
}
