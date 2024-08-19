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
        public async Task<ActionResult<TicketResponseDto>> GetByIdAsync(int id)
        {
            var ticketHistory = await _ticketHistoryService.GetByIdAsync(id);
            if (ticketHistory == null)
            {
                return NotFound(CreateDynamicErrorResponse("Ticket history", id, "found", 404));
            }

            var ticketHistoryDto = new TicketHistoryDTO
            {
                HistoryId = ticketHistory.HistoryId,
                TicketId = ticketHistory.TicketId,
                UserId = ticketHistory.UserId,
                ActionId = ticketHistory.ActionId,
                ActionDate = ticketHistory.ActionDate,
                Details = ticketHistory.Details
            };

            return Ok(ticketHistoryDto);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TicketHistoryDTO>>> GetAllAsync()
        {
            var ticketHistories = await _ticketHistoryService.GetAllAsync();
            var ticketHistoryDtos = new List<TicketHistoryDTO>();

            foreach (var ticketHistory in ticketHistories)
            {
                ticketHistoryDtos.Add(new TicketHistoryDTO
                {
                    HistoryId = ticketHistory.HistoryId,
                    TicketId = ticketHistory.TicketId,
                    UserId = ticketHistory.UserId,
                    ActionId = ticketHistory.ActionId,
                    ActionDate = ticketHistory.ActionDate,
                    Details = ticketHistory.Details
                });
            }

            return Ok(ticketHistoryDtos);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(TicketHistoryCreateDTO ticketHistoryCreateDTO)
        {
            var ticketHistory = new TicketHistory
            {
                TicketId = ticketHistoryCreateDTO.TicketId,
                UserId = ticketHistoryCreateDTO.UserId,
                ActionId = ticketHistoryCreateDTO.ActionId,
                ActionDate = ticketHistoryCreateDTO.ActionDate,
                Details = ticketHistoryCreateDTO.Details
            };

            await _ticketHistoryService.AddAsync(ticketHistory);

            return Ok(CreateResponse(true, "Ticket history created successfully", 200));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, TicketHistoryDTO ticketHistoryDto)
        {
            var ticketHistory = await _ticketHistoryService.GetByIdAsync(id);
            if (ticketHistory == null)
            {
                return NotFound(CreateDynamicErrorResponse("Ticket history", id, "updated", 404));
            }

            ticketHistory.TicketId = ticketHistoryDto.TicketId;
            ticketHistory.UserId = ticketHistoryDto.UserId;
            ticketHistory.ActionId = ticketHistoryDto.ActionId;
            ticketHistory.ActionDate = ticketHistoryDto.ActionDate;
            ticketHistory.Details = ticketHistoryDto.Details;

            await _ticketHistoryService.UpdateAsync(ticketHistory);

            return Ok(CreateResponse(true, "Ticket history updated successfully", 200));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var ticketHistory = await _ticketHistoryService.GetByIdAsync(id);
            if (ticketHistory == null)
            {
                return NotFound(CreateDynamicErrorResponse("Ticket history", id, "deleted", 404));
            }

            await _ticketHistoryService.DeleteAsync(id);
            return Ok(CreateResponse(true, "Ticket history deleted successfully", 200));
        }

        private TicketResponseDto CreateResponse(bool isSuccess, string message, int messageCode)
        {
            return new TicketResponseDto
            {
                IsSuccess = isSuccess,
                Message = message,
                MessageCode = messageCode
            };
        }

        private TicketResponseDto CreateDynamicErrorResponse(string entityName, int entityId, string action, int messageCode)
        {
            return new TicketResponseDto
            {
                IsSuccess = false,
                Message = $"{entityName} with ID {entityId} could not be {action}.",
                MessageCode = messageCode
            };
        }
    }
}
