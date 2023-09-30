using TicketEase.Dtos.Trains;
using TicketEase.Responses;

namespace TicketEase.Contracts
{
    public interface ITrainService
    {
        public Task<ApiResponse> CreateTrain(CreateTrainDto trainDto);
        public Task<ApiResponse> UpdateTrain(string id, UpdateTrainDto trainDto);
        public Task<ApiResponse> GetTrains();
        public Task<ApiResponse> GetTrain(string id);
        public Task<ApiResponse> DeleteTrain(string id);
    }
}
