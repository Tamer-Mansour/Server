using Microsoft.AspNetCore.Mvc;
using Server.DTOs.TicketCategoryAssignmentsDTOs;
using Server.Models;
using Server.Services.CategoryAssignment;
using Server.Utilities;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketCategoryAssignmentController : ControllerBase
    {
        private readonly ITicketCategoryAssignmentService _ticketCategoryAssignmentService;

        public TicketCategoryAssignmentController(ITicketCategoryAssignmentService ticketCategoryAssignmentService)
        {
            _ticketCategoryAssignmentService = ticketCategoryAssignmentService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var ticketCategoryAssignment = await _ticketCategoryAssignmentService.GetByIdAsync(id);
            if (ticketCategoryAssignment == null)
            {
                return NotFound(ResponseHelper.CreateDynamicErrorResponse("Ticket category assignment", id, "retrieved", 404));
            }

            var ticketCategoryAssignmentDto = new TicketCategoryAssignmentDTO
            {
                AssignmentId = ticketCategoryAssignment.AssignmentId,
                TicketId = ticketCategoryAssignment.TicketId,
                CategoryId = ticketCategoryAssignment.CategoryId
            };

            return Ok(ticketCategoryAssignmentDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var ticketCategoryAssignments = await _ticketCategoryAssignmentService.GetAllAsync();
            var ticketCategoryAssignmentDtos = ticketCategoryAssignments.Select(ticketCategoryAssignment => new TicketCategoryAssignmentDTO
            {
                AssignmentId = ticketCategoryAssignment.AssignmentId,
                TicketId = ticketCategoryAssignment.TicketId,
                CategoryId = ticketCategoryAssignment.CategoryId
            }).ToList();

            return Ok(ticketCategoryAssignmentDtos);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(TicketCategoryAssignmentCreateDTO ticketCategoryAssignmentCreateDto)
        {
            var ticketCategoryAssignment = new TicketCategoryAssignment
            {
                TicketId = ticketCategoryAssignmentCreateDto.TicketId,
                CategoryId = ticketCategoryAssignmentCreateDto.CategoryId
            };

            await _ticketCategoryAssignmentService.AddAsync(ticketCategoryAssignment);

            return Ok(ResponseHelper.CreateResponse(true, "Ticket category assignment created successfully", 201));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, TicketCategoryAssignmentDTO ticketCategoryAssignmentDto)
        {
            var ticketCategoryAssignment = await _ticketCategoryAssignmentService.GetByIdAsync(id);
            if (ticketCategoryAssignment == null)
            {
                return NotFound(ResponseHelper.CreateDynamicErrorResponse("Ticket category assignment", id, "updated", 404));
            }

            ticketCategoryAssignment.TicketId = ticketCategoryAssignmentDto.TicketId;
            ticketCategoryAssignment.CategoryId = ticketCategoryAssignmentDto.CategoryId;

            await _ticketCategoryAssignmentService.UpdateAsync(ticketCategoryAssignment);

            return Ok(ResponseHelper.CreateResponse(true, "Ticket category assignment updated successfully", 200));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var ticketCategoryAssignment = await _ticketCategoryAssignmentService.GetByIdAsync(id);
            if (ticketCategoryAssignment == null)
            {
                return NotFound(ResponseHelper.CreateDynamicErrorResponse("Ticket category assignment", id, "deleted", 404));
            }

            await _ticketCategoryAssignmentService.DeleteAsync(id);

            return Ok(ResponseHelper.CreateResponse(true, "Ticket category assignment deleted successfully", 200));
        }
    }
}
