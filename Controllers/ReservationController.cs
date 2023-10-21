using Microsoft.AspNetCore.Mvc;
using TicketEase.Contracts;
using TicketEase.Dtos.Reservation;
using TicketEase.Responses;

namespace TicketEase.Controllers
{
    [Route("api/reservations")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        IReservationService _service;

        public ReservationController(IReservationService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<ApiResponse>> GetReservations()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ApiResponse response = await _service.GetReservations();

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
        public async Task<ActionResult<ApiResponse>> CreateReservation(CreateReservationDto createReservation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ApiResponse response = await _service.CreateReservation(createReservation);

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
        public async Task<ActionResult<ApiResponse>> DeleteReservation(string reservationId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ApiResponse response = await _service.DeleteReservation(reservationId);

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
