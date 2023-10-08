using TicketEase.Dtos.Reservation;
using TicketEase.Responses;

namespace TicketEase.Contracts
{
    public interface IReservationService
    {
        public Task<ApiResponse> CreateReservation(CreateReservationDto createReservation);
    }
}
