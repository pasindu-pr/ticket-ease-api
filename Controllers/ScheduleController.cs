using Microsoft.AspNetCore.Mvc;
using TicketEase.Contracts;
using TicketEase.Dtos.Schedule;
using TicketEase.Responses;

namespace TicketEase.Controllers
{
    [Route("api/schedules")]
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

        [HttpPost("add-stations")]
        public async Task<ActionResult<ApiResponse>> AddStationToSchedule(AddStationsToScheduleDto stationsToScheduleDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ApiResponse response = await _service.AddStationsToSchedule(stationsToScheduleDto);

            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        [HttpPost("add-train")]
        public async Task<ActionResult<ApiResponse>> AddTrainToSchedule(AddTrainToScheduleDto trainToScheduleDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ApiResponse response = await _service.AddTrainToSchedule(trainToScheduleDto);

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
