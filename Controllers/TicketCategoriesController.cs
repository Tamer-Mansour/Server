using Microsoft.AspNetCore.Mvc;
using Server.Models;
using Server.DTOs;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Server.DTOs.TicketCategoriesDTOs;
using Server.Services.TicketCategories;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketCategoriesController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly ITicketCategoryService _ticketCategoryService;
        public TicketCategoriesController(AppDbContext context, ITicketCategoryService ticketCategoryService)
        {
            _context = context;
            _ticketCategoryService = ticketCategoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTicketCategories(int pageNumber, int pageSize)
        {
            var result = await _ticketCategoryService.GetPaginatedAsync(pageNumber, pageSize);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTicketCategory(int id)
        {
            var result = await _ticketCategoryService.GetByIdAsync(id);

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<TicketCategoryDTO>> PostTicketCategory(TicketCategoryCreateDTO createDTO)
        {

            var result = await _ticketCategoryService.AddAsync(createDTO);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutTicketCategory(int id, TicketCategoryUpdateDTO updateDTO)
        {
            var result = await _ticketCategoryService.UpdateAsync(id, updateDTO);

            return Ok(result);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTicketCategory(int id)
        {
            var result = await _ticketCategoryService.DeleteAsync(id);

            return Ok(result);
        }
    }
}
