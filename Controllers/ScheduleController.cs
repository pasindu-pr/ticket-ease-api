using Microsoft.AspNetCore.Mvc;
using TicketEase.Contracts;
using TicketEase.Dtos.Schedule;
using TicketEase.Dtos.Station;
using TicketEase.Responses;
using TicketEase.Services;

namespace TicketEase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        public IScheduleService _service;
        public ScheduleController(IScheduleService scheduleService)
        {
            _service = scheduleService;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse>> GetSchedules()
        {
            ApiResponse response = await _service.GetSchedulesAsync();

            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse>> GetStation(string id)
        {
            ApiResponse response = await _service.GetScheduleAsync(id);

            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        [HttpPost]
        public async Task<ActionResult<ApiResponse>> CreateSchedule(CreateScheduleDto scheduleDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ApiResponse response = await _service.AddScheduleAsync(scheduleDto);

            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        [HttpPut]
        public async Task<ActionResult<ApiResponse>> UpdateStation(string id, UpdateScheduleDto scheduleDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ApiResponse response = await _service.UpdateScheduleAsync(id, scheduleDto);

            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        [HttpDelete]
        public async Task<ActionResult<ApiResponse>> DeleteSchedule(string id)
        {
            if (id == null)
            {
                return BadRequest("Schedule id not found");
            }

            ApiResponse response = await _service.DeleteScheduleAsync(id);

            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }
    }
}
