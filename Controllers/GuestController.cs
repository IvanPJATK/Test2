using Microsoft.AspNetCore.Mvc;
using WebApplicationTest2.DTOs;
using WebApplicationTest2.Services;

namespace WebApplicationTest2.Controllers
{
    [ApiController]
    [Route("api")]
    public class GuestController : ControllerBase
    {
        private readonly IGuestService _service;
        public GuestController(IGuestService service) { _service = service; }
        [HttpGet("rooms/{id}/guests")]
        public async Task<IActionResult> GetRoomDetails(int id)
        {
            var result = await _service.GetRoomDetailsAsync(id);
            if(result == null)
            {
                return NotFound($"No room with id {id}");
            }
            return Ok(result);
        }
        [HttpPost("guests")]
        public async Task<IActionResult> AddNewGuest([FromBody] PostGuestDto guest)
        {
            var result = await _service.AddNewGuest(guest);
            if(!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
    }
}
