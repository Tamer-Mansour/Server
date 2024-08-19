using Microsoft.AspNetCore.Mvc;
using Server.DTOs.TicketAttachmentsDTOs;
using Server.DTOs.TicketsDTOs;
using Server.Models;
using Server.Services.TicketAttachments;
using Server.Utilities;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketAttachmentController : ControllerBase
    {
        private readonly ITicketAttachmentService _ticketAttachmentService;

        public TicketAttachmentController(ITicketAttachmentService ticketAttachmentService)
        {
            _ticketAttachmentService = ticketAttachmentService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var ticketAttachment = await _ticketAttachmentService.GetByIdAsync(id);
            if (ticketAttachment == null)
            {
                return NotFound(ResponseHelper.CreateDynamicErrorResponse("Ticket attachment", id, "retrieved", 404));
            }

            var ticketAttachmentDto = new TicketAttachmentDTO
            {
                AttachmentId = ticketAttachment.AttachmentId,
                TicketId = ticketAttachment.TicketId,
                FilePath = ticketAttachment.FilePath,
                FileName = ticketAttachment.FileName,
                UploadedAt = ticketAttachment.UploadedAt
            };

            return Ok(ticketAttachmentDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var ticketAttachments = await _ticketAttachmentService.GetAllAsync();
            var ticketAttachmentDtos = ticketAttachments.Select(ticketAttachment => new TicketAttachmentDTO
            {
                AttachmentId = ticketAttachment.AttachmentId,
                TicketId = ticketAttachment.TicketId,
                FilePath = ticketAttachment.FilePath,
                FileName = ticketAttachment.FileName,
                UploadedAt = ticketAttachment.UploadedAt
            }).ToList();

            return Ok(ticketAttachmentDtos);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(TicketAttachmentCreateDTO ticketAttachmentCreateDto)
        {
            var ticketAttachment = new TicketAttachment
            {
                TicketId = ticketAttachmentCreateDto.TicketId,
                FilePath = ticketAttachmentCreateDto.FilePath,
                FileName = ticketAttachmentCreateDto.FileName,
                UploadedAt = ticketAttachmentCreateDto.UploadedAt
            };

            await _ticketAttachmentService.AddAsync(ticketAttachment);

            return Ok(ResponseHelper.CreateResponse(true, "Ticket attachment created successfully", 201));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, TicketAttachmentDTO ticketAttachmentDto)
        {
            var ticketAttachment = await _ticketAttachmentService.GetByIdAsync(id);
            if (ticketAttachment == null)
            {
                return NotFound(ResponseHelper.CreateDynamicErrorResponse("Ticket attachment", id, "updated", 404));
            }

            ticketAttachment.TicketId = ticketAttachmentDto.TicketId;
            ticketAttachment.FilePath = ticketAttachmentDto.FilePath;
            ticketAttachment.FileName = ticketAttachmentDto.FileName;
            ticketAttachment.UploadedAt = ticketAttachmentDto.UploadedAt;

            await _ticketAttachmentService.UpdateAsync(ticketAttachment);

            return Ok(ResponseHelper.CreateResponse(true, "Ticket attachment updated successfully", 200));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var ticketAttachment = await _ticketAttachmentService.GetByIdAsync(id);
            if (ticketAttachment == null)
            {
                return NotFound(ResponseHelper.CreateDynamicErrorResponse("Ticket attachment", id, "deleted", 404));
            }

            await _ticketAttachmentService.DeleteAsync(id);

            return Ok(ResponseHelper.CreateResponse(true, "Ticket attachment deleted successfully", 200));
        }
    }
}
