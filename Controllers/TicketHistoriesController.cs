using Microsoft.AspNetCore.Mvc;
using Server.DTOs.TicketHistoriesDTOs;
using Server.DTOs.TicketsDTOs;
using Server.Models;
using Server.Services.TicketHistories;


namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketHistoriesController : ControllerBase
    {
        private readonly ITicketHistoryService _ticketHistoryService;

        public TicketHistoriesController(ITicketHistoryService ticketHistoryService)
        {
            _ticketHistoryService = ticketHistoryService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetByIdAsync(int id)
        {
            var result = await _ticketHistoryService.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult> GetAllAsync(int pageNumber, int pageSize)
        {
            var result = await _ticketHistoryService.GetAllAsync(pageNumber, pageSize);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(TicketHistoryCreateDTO ticketHistoryCreateDTO)
        {
            var result = await _ticketHistoryService.AddAsync(ticketHistoryCreateDTO);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, TicketHistoryUpdateDTO ticketHistoryUpdateDTO)
        {
            var result = await _ticketHistoryService.UpdateAsync(id, ticketHistoryUpdateDTO);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _ticketHistoryService.DeleteAsync(id);
            return Ok(result);
        }
    }
}
