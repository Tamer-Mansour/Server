using Microsoft.AspNetCore.Mvc;
using Server.DTOs.TicketCommentsDTOs;
using Server.Models;
using Server.Services.TicketComments;
using Server.Utilities;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketCommentController : ControllerBase
    {
        private readonly ITicketCommentService _ticketCommentService;

        public TicketCommentController(ITicketCommentService ticketCommentService)
        {
            _ticketCommentService = ticketCommentService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var ticketComment = await _ticketCommentService.GetByIdAsync(id);
            if (ticketComment == null)
            {
                return NotFound(ResponseHelper.CreateDynamicErrorResponse("Ticket comment", id, "retrieved", 404));
            }

            var ticketCommentDto = new TicketCommentDTO
            {
                CommentId = ticketComment.CommentId,
                TicketId = ticketComment.TicketId,
                UserId = ticketComment.UserId,
                Comment = ticketComment.Comment,
                CreatedAt = ticketComment.CreatedAt
            };

            return Ok(ticketCommentDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var ticketComments = await _ticketCommentService.GetAllAsync();
            var ticketCommentDtos = ticketComments.Select(ticketComment => new TicketCommentDTO
            {
                CommentId = ticketComment.CommentId,
                TicketId = ticketComment.TicketId,
                UserId = ticketComment.UserId,
                Comment = ticketComment.Comment,
                CreatedAt = ticketComment.CreatedAt
            }).ToList();

            return Ok(ticketCommentDtos);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(TicketCommentCreateDTO ticketCommentCreateDto)
        {
            var ticketComment = new TicketComment
            {
                TicketId = ticketCommentCreateDto.TicketId,
                UserId = ticketCommentCreateDto.UserId,
                Comment = ticketCommentCreateDto.Comment,
                CreatedAt = ticketCommentCreateDto.CreatedAt
            };

            await _ticketCommentService.AddAsync(ticketComment);

            return Ok(ResponseHelper.CreateResponse(true, "Ticket comment created successfully", 201));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, TicketCommentDTO ticketCommentDto)
        {
            var ticketComment = await _ticketCommentService.GetByIdAsync(id);
            if (ticketComment == null)
            {
                return NotFound(ResponseHelper.CreateDynamicErrorResponse("Ticket comment", id, "updated", 404));
            }

            ticketComment.TicketId = ticketCommentDto.TicketId;
            ticketComment.UserId = ticketCommentDto.UserId;
            ticketComment.Comment = ticketCommentDto.Comment;
            ticketComment.CreatedAt = ticketCommentDto.CreatedAt;

            await _ticketCommentService.UpdateAsync(ticketComment);

            return Ok(ResponseHelper.CreateResponse(true, "Ticket comment updated successfully", 200));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var ticketComment = await _ticketCommentService.GetByIdAsync(id);
            if (ticketComment == null)
            {
                return NotFound(ResponseHelper.CreateDynamicErrorResponse("Ticket comment", id, "deleted", 404));
            }

            await _ticketCommentService.DeleteAsync(id);

            return Ok(ResponseHelper.CreateResponse(true, "Ticket comment deleted successfully", 200));
        }
    }
}
