using Microsoft.AspNetCore.Mvc;
using Server.DTOs.Pagination;
using Server.DTOs.TicketsDTOs;
using Server.Services.Tickets;

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
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync(int pageNumber, int pageSize)
        {
            var result = await _ticketService.GetAllAsync(pageNumber, pageSize);
            return Ok(result);
        }
        [HttpGet("active-tickets")]
        public async Task<IActionResult> GetActiveTickets(int pageNumber, int pageSize)
        {
            var result = await _ticketService.GetActiveTicketsAsync(pageNumber, pageSize);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(TicketCreateDTO ticketCreateDto)
        {
            var result = await _ticketService.AddAsync(ticketCreateDto, User?.Identity?.Name);
            return result.IsSuccess ? Ok(result) : BadRequest(result);
        }

        [HttpPut("{ticketId}/Customer/{userId}")]
        public async Task<IActionResult> UpdateCustomerAsync(int ticketId, string userId, TicketUpdateCustomerDTO ticketUpdateCustomerDTO)
        {
            var result = await _ticketService.UpdateCustomerAsync(ticketId, userId, ticketUpdateCustomerDTO);
            return result.IsSuccess ? Ok(result) : NotFound(result);
        }

        [HttpPut("{ticketId}/Support/{userId}")]
        public async Task<IActionResult> UpdateSupportAsync(int ticketId, string userId, TicketUpdateSupportDTO ticketUpdateSupportDTO)
        {
            var result = await _ticketService.UpdateSupportAsync(ticketId, userId, ticketUpdateSupportDTO);
            return result.IsSuccess ? Ok(result) : NotFound(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _ticketService.DeleteAsync(id);
            return result.IsSuccess ? Ok(result) : NotFound(result);
        }

        [HttpGet("priority/{priorityId}")]
        public async Task<IActionResult> GetTicketsByPriorityAsync(int priorityId)
        {
            var result = await _ticketService.GetTicketsByPriorityAsync(priorityId);
            return result.IsSuccess ? Ok(result) : NotFound(result);
        }

        [HttpGet("status/{statusId}")]
        public async Task<IActionResult> GetTicketsByStatusAsync(int statusId)
        {
            var result = await _ticketService.GetTicketsByStatusAsync(statusId);
            return result.IsSuccess ? Ok(result) : NotFound(result);
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetTicketsByUserAsync(string userId)
        {
            var result = await _ticketService.GetTicketsByUserAsync(userId);
            return Ok(result);
        }

        [HttpGet("assigned-to/{userId}")]
        public async Task<IActionResult> GetTicketsAssignedToUserAsync(string userId)
        {
            var result = await _ticketService.GetTicketsAssignedToUserAsync(userId);
            return Ok(result);
        }

        [HttpGet("count")]
        public async Task<IActionResult> GetTotalTicketCount()
        {
            var count = await _ticketService.GetTotalTicketCountAsync();
            return Ok(count);
        }

        [HttpGet("active/count")]
        public async Task<IActionResult> GetActiveTicketCount()
        {
            var count = await _ticketService.GetActiveTicketCountAsync();
            return Ok(count);
        }

        [HttpGet("resolved/count")]
        public async Task<IActionResult> GetResolvedTicketCount()
        {
            var count = await _ticketService.GetResolvedTicketCountAsync();
            return Ok(count);
        }

        [HttpGet("history/count")]
        public async Task<IActionResult> GetHistoryTicketCount()
        {
            var count = await _ticketService.GetHistoryTicketCountAsync();
            return Ok(count);
        }

        [HttpGet("category/{categoryId}")]
        public async Task<IActionResult> GetTicketsByCategory(int categoryId)
        {
            var tickets = await _ticketService.GetTicketsByCategoryAsync(categoryId);
            return Ok(tickets);
        }
    }
}
