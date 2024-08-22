using Microsoft.AspNetCore.Mvc;
using Server.DTOs.TicketStatusesDTOs;
using Server.Services.TicketStatuses;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketStatusController : ControllerBase
    {
        private readonly ITicketStatusService _ticketStatusService;

        public TicketStatusController(ITicketStatusService ticketStatusService)
        {
            _ticketStatusService = ticketStatusService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _ticketStatusService.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _ticketStatusService.GetAllAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(TicketStatusCreateDTO ticketStatusCreateDto)
        {
            var result = await _ticketStatusService.AddAsync(ticketStatusCreateDto);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, TicketStatusUpdateDTO ticketStatusUpdateDTO)
        {
            var result = await _ticketStatusService.UpdateAsync(id, ticketStatusUpdateDTO);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _ticketStatusService.DeleteAsync(id);
            return Ok(result);
        }
    }
}
