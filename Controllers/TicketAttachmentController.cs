using Microsoft.AspNetCore.Mvc;
using Server.DTOs.TicketAttachmentsDTOs;
using Server.Services.TicketAttachments;
using System.Collections.Generic;
using System.Threading.Tasks;

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
            var result = await _ticketAttachmentService.GetTicketAttachmentByIdAsync(id);
            return result != null ? Ok(result) : NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _ticketAttachmentService.GetAllTicketAttachmentAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(TicketAttachmentCreateDTO ticketAttachmentCreateDto)
        {
            var result = await _ticketAttachmentService.AddTicketAttachmentAsync(ticketAttachmentCreateDto);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, TicketAttachmentUpdateDTO ticketAttachmentUpdateDto)
        {
            var result = await _ticketAttachmentService.UpdateTicketAttachmentAsync(id, ticketAttachmentUpdateDto);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _ticketAttachmentService.DeleteTicketAttachmentAsync(id);
            return Ok(result);
        }

        [HttpGet("paginated")]
        public async Task<IActionResult> GetPaginatedTicketAttachments(int pageNumber, int pageSize)
        {
            var result = await _ticketAttachmentService.GetPaginatedTicketAttachmentsAsync(pageNumber, pageSize);
            return Ok(result);
        }
    }
}
