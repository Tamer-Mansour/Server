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
            var result = await _ticketCategoryAssignmentService.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync(int pageNumber, int pageSize)
        {
            var result = await _ticketCategoryAssignmentService.GetAllAsync(pageNumber, pageSize);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(TicketCategoryAssignmentCreateDTO ticketCategoryAssignmentCreateDto)
        {
            var result = await _ticketCategoryAssignmentService.AddAsync(ticketCategoryAssignmentCreateDto);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, TicketCategoryAssignmentUpdateDTO ticketCategoryAssignmentUpdateDTO)
        {
            var result = await _ticketCategoryAssignmentService.UpdateAsync(id, ticketCategoryAssignmentUpdateDTO);
            return Ok(result);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var result = await _ticketCategoryAssignmentService.DeleteAsync(id);
            return Ok(result);
        }
    }
}
