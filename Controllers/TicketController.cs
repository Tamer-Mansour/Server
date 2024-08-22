using Microsoft.AspNetCore.Mvc;
using Server.DTOs.TicketsDTOs;
using Server.Models;
using Server.Services.Tickets;
using Server.Utilities;
using System.Drawing.Printing;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;

        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _ticketService.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync(int pageNumber, int pageSize)
        {
            var result = await _ticketService.GetAllAsync(pageNumber, pageSize);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(TicketCreateDTO ticketCreateDto)
        {
            var result = await _ticketService.AddAsync(ticketCreateDto);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, TicketUpdateDTO ticketUpdateDTO)
        {
            var result = await _ticketService.UpdateAsync(id, ticketUpdateDTO);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _ticketService.DeleteAsync(id);
            return Ok(result);
        }
        [HttpGet("priority/{priorityId}")]
        public async Task<IActionResult> GetTicketsByPriorityAsync(int priorityId)
        {
            var result = await _ticketService.GetTicketsByPriorityAsync(priorityId);
            return Ok(result);
        }

        [HttpGet("status/{statuesId}")]
        public async Task<IActionResult> GetTicketsByStatusAsync(int statuesId)
        {
            var result = await _ticketService.GetTicketsByStatusAsync(statuesId);
            return Ok(result);
        }
    }
}
