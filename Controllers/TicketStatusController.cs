using Microsoft.AspNetCore.Mvc;
using Server.DTOs.TicketStatusesDTOs;
using Server.Models;
using Server.Services.TicketStatuses;
using Server.Utilities;

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
            var ticketStatus = await _ticketStatusService.GetByIdAsync(id);
            if (ticketStatus == null)
            {
                return NotFound(ResponseHelper.CreateDynamicErrorResponse("Ticket status", id, "retrieved", 404));
            }

            var ticketStatusDto = new TicketStatusDTO
            {
                StatusId = ticketStatus.StatusId,
                StatusName = ticketStatus.StatusName
            };

            return Ok(ticketStatusDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var ticketStatuses = await _ticketStatusService.GetAllAsync();
            var ticketStatusDtos = ticketStatuses.Select(ticketStatus => new TicketStatusDTO
            {
                StatusId = ticketStatus.StatusId,
                StatusName = ticketStatus.StatusName
            }).ToList();

            return Ok(ticketStatusDtos);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(TicketStatusCreateDTO ticketStatusCreateDto)
        {
            var ticketStatus = new TicketStatus
            {
                StatusName = ticketStatusCreateDto.StatusName
            };

            await _ticketStatusService.AddAsync(ticketStatus);

            return Ok(ResponseHelper.CreateResponse(true, "Ticket status created successfully", 201));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, TicketStatusDTO ticketStatusDto)
        {
            var ticketStatus = await _ticketStatusService.GetByIdAsync(id);
            if (ticketStatus == null)
            {
                return NotFound(ResponseHelper.CreateDynamicErrorResponse("Ticket status", id, "updated", 404));
            }

            ticketStatus.StatusName = ticketStatusDto.StatusName;

            await _ticketStatusService.UpdateAsync(ticketStatus);

            return Ok(ResponseHelper.CreateResponse(true, "Ticket status updated successfully", 200));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var ticketStatus = await _ticketStatusService.GetByIdAsync(id);
            if (ticketStatus == null)
            {
                return NotFound(ResponseHelper.CreateDynamicErrorResponse("Ticket status", id, "deleted", 404));
            }

            await _ticketStatusService.DeleteAsync(id);

            return Ok(ResponseHelper.CreateResponse(true, "Ticket status deleted successfully", 200));
        }
    }
}
