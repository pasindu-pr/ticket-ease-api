using TicketEase.Dtos.Reservation;
using TicketEase.Responses;

namespace TicketEase.Contracts
{
    public interface IReservationService
    {
        public Task<ApiResponse> CreateReservation(CreateReservationDto createReservation);
        public Task<ApiResponse> GetReservations();
        public Task<ApiResponse> DeleteReservation(string reservationId);
        public Task<ApiResponse> GetCancelledReservations();
        public Task<ApiResponse> GetAllReservationsAsync();
    }
}
