using Microsoft.AspNetCore.Mvc;
using Server.Models;
using Server.DTOs;
using Microsoft.EntityFrameworkCore;
using Server.DTOs.TicketCategory;
using Server.Data;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketCategoriesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TicketCategoriesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/TicketCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TicketCategoryDto>>> GetTicketCategories()
        {
            return await _context.TicketCategories
                .Select(tc => new TicketCategoryDto
                {
                    CategoryId = tc.CategoryId,
                    CategoryName = tc.CategoryName
                })
                .ToListAsync();
        }

        // GET: api/TicketCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TicketCategoryDto>> GetTicketCategory(int id)
        {
            var ticketCategory = await _context.TicketCategories.FindAsync(id);

            if (ticketCategory == null)
            {
                return NotFound();
            }

            return new TicketCategoryDto
            {
                CategoryId = ticketCategory.CategoryId,
                CategoryName = ticketCategory.CategoryName
            };
        }

        // POST: api/TicketCategories
        [HttpPost]
        public async Task<ActionResult<TicketCategoryDto>> PostTicketCategory(CreateTicketCategoryDto createDTO)
        {
            var ticketCategory = new TicketCategory
            {
                CategoryName = createDTO.CategoryName
            };

            _context.TicketCategories.Add(ticketCategory);
            await _context.SaveChangesAsync();

            var ticketCategoryDTO = new TicketCategoryDto
            {
                CategoryId = ticketCategory.CategoryId,
                CategoryName = ticketCategory.CategoryName
            };
            /**/

            return CreatedAtAction(nameof(GetTicketCategory), new { id = ticketCategoryDTO.CategoryId }, ticketCategoryDTO);
        }

        // PUT: api/TicketCategories/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTicketCategory(int id, UpdateTicketCategoryDto updateDTO)
        {
            var ticketCategory = await _context.TicketCategories.FindAsync(id);
            if (ticketCategory == null)
            {
                return NotFound();
            }

            ticketCategory.CategoryName = updateDTO.CategoryName;

            _context.Entry(ticketCategory).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/TicketCategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTicketCategory(int id)
        {
            var ticketCategory = await _context.TicketCategories.FindAsync(id);
            if (ticketCategory == null)
            {
                return NotFound();
            }

            _context.TicketCategories.Remove(ticketCategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
