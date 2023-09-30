using Microsoft.AspNetCore.Mvc;
using TicketEase.Contracts;
using TicketEase.Dtos.Trains;
using TicketEase.Responses;

namespace TicketEase.Controllers
{
    [Route("api/trains")]
    [ApiController]
    public class TrainController : ControllerBase
    {
        ITrainService _trainService;

        public TrainController(ITrainService trainService)
        {
            _trainService = trainService;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse>> GetTrains()
        {
            ApiResponse response = await _trainService.GetTrains();

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
        public async Task<ActionResult<ApiResponse>> GetTrain(string id)
        {
            ApiResponse response = await _trainService.GetTrain(id);

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
        public async Task<ActionResult<ApiResponse>> CreateTrain(CreateTrainDto train)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ApiResponse response = await _trainService.CreateTrain(train);

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
        public async Task<ActionResult<ApiResponse>> UpdateTrain(string id, UpdateTrainDto train)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ApiResponse response = await _trainService.UpdateTrain(id, train);

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
        public async Task<ActionResult<ApiResponse>> DeleteTrain(string id)
        {
            if (id == null)
            {
                return BadRequest("Train id not found");
            }

            ApiResponse response = await _trainService.DeleteTrain(id);

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
