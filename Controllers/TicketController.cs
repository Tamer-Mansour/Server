using Microsoft.AspNetCore.Mvc;
using Server.DTOs.TicketsDTOs;
using Server.Models;
using Server.Services.Tickets;
using Server.Utilities;

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
            var ticket = await _ticketService.GetByIdAsync(id);
            if (ticket == null)
            {
                return NotFound(ResponseHelper.CreateDynamicErrorResponse("Ticket", id, "retrieved", 404));
            }

            var ticketDto = new TicketDTO
            {
                TicketId = ticket.TicketId,
                Title = ticket.Title,
                Description = ticket.Description,
                StatusId = ticket.StatusId,
                PriorityId = ticket.PriorityId,
                CreatedAt = ticket.CreatedAt,
                UpdatedAt = ticket.UpdatedAt,
                ResolvedAt = ticket.ResolvedAt,
                ClosedAt = ticket.ClosedAt,
                UserId = ticket.UserId
            };

            return Ok(ticketDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var tickets = await _ticketService.GetAllAsync();
            var ticketDtos = tickets.Select(ticket => new TicketDTO
            {
                TicketId = ticket.TicketId,
                Title = ticket.Title,
                Description = ticket.Description,
                StatusId = ticket.StatusId,
                PriorityId = ticket.PriorityId,
                CreatedAt = ticket.CreatedAt,
                UpdatedAt = ticket.UpdatedAt,
                ResolvedAt = ticket.ResolvedAt,
                ClosedAt = ticket.ClosedAt,
                UserId = ticket.UserId
            }).ToList();

            return Ok(ticketDtos);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(TicketCreateDTO ticketCreateDto)
        {
            var ticket = new Ticket
            {
                Title = ticketCreateDto.Title,
                Description = ticketCreateDto.Description,
                StatusId = ticketCreateDto.StatusId,
                PriorityId = ticketCreateDto.PriorityId,
                CreatedAt = ticketCreateDto.CreatedAt,
                UpdatedAt = ticketCreateDto.UpdatedAt,
                ResolvedAt = ticketCreateDto.ResolvedAt,
                ClosedAt = ticketCreateDto.ClosedAt,
                UserId = ticketCreateDto.UserId
            };

            await _ticketService.AddAsync(ticket);

            return CreatedAtAction(nameof(GetByIdAsync), new { id = ticket.TicketId }, ResponseHelper.CreateResponse(true, "Ticket created successfully", 201));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, TicketDTO ticketDto)
        {
            var existingTicket = await _ticketService.GetByIdAsync(id);
            if (existingTicket == null)
            {
                return NotFound(ResponseHelper.CreateDynamicErrorResponse("Ticket", id, "updated", 404));
            }

            existingTicket.Title = ticketDto.Title;
            existingTicket.Description = ticketDto.Description;
            existingTicket.StatusId = ticketDto.StatusId;
            existingTicket.PriorityId = ticketDto.PriorityId;
            existingTicket.CreatedAt = ticketDto.CreatedAt;
            existingTicket.UpdatedAt = ticketDto.UpdatedAt;
            existingTicket.ResolvedAt = ticketDto.ResolvedAt;
            existingTicket.ClosedAt = ticketDto.ClosedAt;
            existingTicket.UserId = ticketDto.UserId;

            await _ticketService.UpdateAsync(existingTicket);

            return Ok(ResponseHelper.CreateResponse(true, "Ticket updated successfully", 200));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var existingTicket = await _ticketService.GetByIdAsync(id);
            if (existingTicket == null)
            {
                return NotFound(ResponseHelper.CreateDynamicErrorResponse("Ticket", id, "deleted", 404));
            }

            await _ticketService.DeleteAsync(id);

            return Ok(ResponseHelper.CreateResponse(true, "Ticket deleted successfully", 200));
        }
    }
}
