using Microsoft.AspNetCore.Mvc;
using Server.DTOs.TicketCommentsDTOs;
using Server.Models;
using Server.Services.TicketComments;
using Server.Utilities;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketCommentController : ControllerBase
    {
        private readonly ITicketCommentService _ticketCommentService;

        public TicketCommentController(ITicketCommentService ticketCommentService)
        {
            _ticketCommentService = ticketCommentService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _ticketCommentService.GetByIdAsync(id);
            return Ok(result);

        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync(int pageNumber, int pageSize)
        {
            var result = await _ticketCommentService.GetAllAsync(pageNumber, pageSize);
            return Ok(result);

        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(TicketCommentCreateDTO ticketCommentCreateDto)
        {
            var result = await _ticketCommentService.AddAsync(ticketCommentCreateDto);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, TicketCommentUpdateDTO ticketCommentUpdateDTO)
        {
            var result = await _ticketCommentService.UpdateAsync(id, ticketCommentUpdateDTO);
            return Ok(result);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _ticketCommentService.DeleteAsync(id);
            return Ok(result);
        }
        [HttpGet("ticket/{ticketId}")]
        public async Task<IActionResult> GetByTicketIdAsync(int ticketId)
        {
            var result = await _ticketCommentService.GetByTicketIdAsync(ticketId);
            return Ok(result);
        }
    }
}
