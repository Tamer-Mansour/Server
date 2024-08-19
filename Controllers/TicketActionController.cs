using Microsoft.AspNetCore.Mvc;
using Server.DTOs.TicketActionsDTOs;
using Server.DTOs.TicketsDTOs;
using Server.Services.TicketActions;


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

        [HttpGet("{id}")]
        public async Task<ActionResult<TicketActionDTO>> GetByIdAsync(int id) =>
            OkOrNotFound(await _ticketActionService.GetTicketActionByIdAsync(id));

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TicketActionListDTO>>> GetAllAsync() =>
            Ok(await _ticketActionService.GetAllTicketActionsAsync());

        [HttpPost]
        public async Task<IActionResult> AddAsync(TicketActionCreateDTO ticketActionCreateDTO) =>
            OkOrBadRequest(await _ticketActionService.AddTicketActionAsync(ticketActionCreateDTO));

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, TicketActionUpdateDTO ticketActionUpdateDTO) =>
            OkOrBadRequest(await _ticketActionService.UpdateTicketActionAsync(id, ticketActionUpdateDTO));

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id) =>
            OkOrNotFound(await _ticketActionService.DeleteTicketActionAsync(id));

        private ActionResult OkOrNotFound<T>(T result) where T : class =>
            result != null ? Ok(result) : NotFound();

        private IActionResult OkOrBadRequest(TicketResponseDto response) =>
            response.IsSuccess ? Ok(response) : BadRequest(response);
    }
}
