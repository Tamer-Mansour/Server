using Microsoft.AspNetCore.Mvc;
using Server.DTOs.TicketPrioritiesDTOs;
using Server.Models;
using Server.Services.TicketPriorities;
using Server.Utilities;

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
            var ticketPriority = await _ticketPriorityService.GetByIdAsync(id);
            if (ticketPriority == null)
            {
                return NotFound(ResponseHelper.CreateDynamicErrorResponse("Ticket priority", id, "retrieved", 404));
            }

            var ticketPriorityDto = new TicketPriorityDTO
            {
                PriorityId = ticketPriority.PriorityId,
                PriorityName = ticketPriority.PriorityName
            };

            return Ok(ticketPriorityDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var ticketPriorities = await _ticketPriorityService.GetAllAsync();
            var ticketPriorityDtos = ticketPriorities.Select(ticketPriority => new TicketPriorityDTO
            {
                PriorityId = ticketPriority.PriorityId,
                PriorityName = ticketPriority.PriorityName
            }).ToList();

            return Ok(ticketPriorityDtos);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(TicketPriorityCreateDTO ticketPriorityCreateDto)
        {
            var ticketPriority = new TicketPriority
            {
                PriorityName = ticketPriorityCreateDto.PriorityName
            };

            await _ticketPriorityService.AddAsync(ticketPriority);

            return Ok(ResponseHelper.CreateResponse(true, "Ticket priority created successfully", 201));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, TicketPriorityDTO ticketPriorityDto)
        {
            var ticketPriority = await _ticketPriorityService.GetByIdAsync(id);
            if (ticketPriority == null)
            {
                return NotFound(ResponseHelper.CreateDynamicErrorResponse("Ticket priority", id, "updated", 404));
            }

            ticketPriority.PriorityName = ticketPriorityDto.PriorityName;

            await _ticketPriorityService.UpdateAsync(ticketPriority);

            return Ok(ResponseHelper.CreateResponse(true, "Ticket priority updated successfully", 200));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var ticketPriority = await _ticketPriorityService.GetByIdAsync(id);
            if (ticketPriority == null)
            {
                return NotFound(ResponseHelper.CreateDynamicErrorResponse("Ticket priority", id, "deleted", 404));
            }

            await _ticketPriorityService.DeleteAsync(id);

            return Ok(ResponseHelper.CreateResponse(true, "Ticket priority deleted successfully", 200));
        }
    }
}
