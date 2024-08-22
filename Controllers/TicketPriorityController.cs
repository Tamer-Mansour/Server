using Microsoft.AspNetCore.Mvc;
using Server.DTOs.TicketPrioritiesDTOs;
using Server.Services.TicketPriorities;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketPriorityController : ControllerBase
    {
        private readonly ITicketPriorityService _ticketPriorityService;

        public TicketPriorityController(ITicketPriorityService ticketPriorityService)
        {
            _ticketPriorityService = ticketPriorityService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _ticketPriorityService.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _ticketPriorityService.GetAllAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(TicketPriorityCreateDTO ticketPriorityCreateDto)
        {
            var result = await _ticketPriorityService.AddAsync(ticketPriorityCreateDto);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, TicketPriorityUpdateDTO ticketPriorityUpdateDTO)
        {
            var result = await _ticketPriorityService.UpdateAsync(id, ticketPriorityUpdateDTO);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _ticketPriorityService.DeleteAsync(id);
            return Ok(result);
        }
    }
}

