using Microsoft.AspNetCore.Mvc;
using Server.DTOs.TicketActionsDTOs;
using Server.Services.TicketActions;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketActionController : ControllerBase
    {
        private readonly ITicketActionService _ticketActionService;

        public TicketActionController(ITicketActionService ticketActionService)
        {
            _ticketActionService = ticketActionService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await _ticketActionService.GetTicketActionByIdAsync(id);
            return result != null ? Ok(result) : NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _ticketActionService.GetAllTicketActionsAsync();
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(TicketActionCreateDTO ticketActionCreateDTO)
        {
            var result = await _ticketActionService.AddTicketActionAsync(ticketActionCreateDTO);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, TicketActionUpdateDTO ticketActionUpdateDTO)
        {
            var result = await _ticketActionService.UpdateTicketActionAsync(id, ticketActionUpdateDTO);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _ticketActionService.DeleteTicketActionAsync(id);
            return Ok(result);
        }
    }
}
