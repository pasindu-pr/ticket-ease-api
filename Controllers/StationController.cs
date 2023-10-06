using Microsoft.AspNetCore.Mvc;
using TicketEase.Contracts;
using TicketEase.Dtos.Station;
using TicketEase.Responses;

namespace TicketEase.Controllers
{
    [Route("api/stations")]
    [ApiController]
    public class StationController : ControllerBase
    {
        IStationService _stationService;

        public StationController(IStationService stationService)
        {
            _stationService = stationService;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse>> GetStations()
        {
            ApiResponse response = await _stationService.GetStations();

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
            ApiResponse response = await _stationService.GetStation(id);

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
        public async Task<ActionResult<ApiResponse>> CreateStation(CreateStationDto stationDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ApiResponse response = await _stationService.CreateStation(stationDto);

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
        public async Task<ActionResult<ApiResponse>> UpdateStation(string id, UpdateStationDto stationDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ApiResponse response = await _stationService.UpdateStation(id, stationDto);

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
        public async Task<ActionResult<ApiResponse>> DeleteStation(string id)
        {
            if (id == null)
            {
                return BadRequest("Station id not found");
            }

            ApiResponse response = await _stationService.DeleteStation(id);

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
