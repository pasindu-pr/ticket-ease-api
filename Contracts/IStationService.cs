using TicketEase.Dtos.Station;
using TicketEase.Responses;

namespace TicketEase.Contracts
{
    public interface IStationService
    {
        public Task<ApiResponse> CreateStation(CreateStationDto stationDto);
        public Task<ApiResponse> UpdateStation(string id, UpdateStationDto stationDto);
        public Task<ApiResponse> GetStations();
        public Task<ApiResponse> GetStation(string id);
        public Task<ApiResponse> DeleteStation(string id);
    }
}
