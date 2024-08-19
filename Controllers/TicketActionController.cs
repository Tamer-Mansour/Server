using Microsoft.AspNetCore.Mvc;
using Server.DTOs.TicketActionsDTOs;
using Server.DTOs.TicketsDTOs;
using Server.Models;
using Server.Services.TicketActions;
using System;


namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketActionController : ControllerBase
    {
        private readonly ITicketActionService _ticketActionService;

        public TicketActionController(ITicketActionService ticketActionService)
        {
            _ticketActionService = ticketActionService;
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

        [HttpGet("{id}")]
        public async Task<ActionResult<TicketResponseDto>> GetByIdAsync(int id)
        {
            var ticketActions = await _ticketActionService.GetByIdAsync(id);
            if (ticketActions == null)
            {
                return NotFound(CreateDynamicErrorResponse("Ticket action", id, "found", 404));
            }

            var ticketActionDto = new TicketActionDTO
            {
                ActionId = ticketActions.ActionId,
                ActionName = ticketActions.ActionName
            };

            return Ok(ticketActionDto);
        }

        [HttpGet]
        public async Task<ActionResult<TicketResponseDto>> GetAllAsync()
        {
            var ticketActions = await _ticketActionService.GetAllAsync();
            var ticketActionDtos = new List<TicketActionDTO>();

            foreach (var ticketAction in ticketActions)
            {
                ticketActionDtos.Add(new TicketActionDTO
                {
                    ActionId = ticketAction.ActionId,
                    ActionName = ticketAction.ActionName
                });
            }

            return Ok(ticketActionDtos);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(TicketActionCreateDTO ticketActionCreateDTO)
        {
            var ticketAction = new TicketAction
            {
                ActionName = ticketActionCreateDTO.ActionName
            };

            await _ticketActionService.AddAsync(ticketAction);

            return Ok(CreateResponse(true, "Ticket action created successfully", 200));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, TicketActionDTO ticketActionDto)
        {
            var ticketAction = await _ticketActionService.GetByIdAsync(id);
            if (ticketAction == null)
            {
                return NotFound(CreateDynamicErrorResponse("Ticket action", id, "updated", 404));
            }

            if (ticketAction.ActionName == ticketActionDto.ActionName)
            {
                return BadRequest(CreateResponse(false, "No changes detected. The action name is already the same.", 400));
            }

            ticketAction.ActionName = ticketActionDto.ActionName;
            await _ticketActionService.UpdateAsync(ticketAction);

            return Ok(CreateResponse(true, "Ticket action updated successfully", 200));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var ticketAction = await _ticketActionService.GetByIdAsync(id);
            if (ticketAction == null)
            {
                return NotFound(CreateDynamicErrorResponse("Ticket action", id, "deleted", 404));
            }

            await _ticketActionService.DeleteAsync(id);
            return Ok(CreateResponse(true, "Ticket action deleted successfully", 200));
        }
    }
}
