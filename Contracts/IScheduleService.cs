using TicketEase.Dtos.Schedule;
using TicketEase.Responses;

namespace TicketEase.Contracts
{
    public interface IScheduleService
    {
        public Task<ApiResponse> GetSchedulesAsync();
        public Task<ApiResponse> GetScheduleAsync(string id);
        public Task<ApiResponse> AddScheduleAsync(CreateScheduleDto schedule);
        public Task<ApiResponse> UpdateScheduleAsync(string id, UpdateScheduleDto schedule);
        public Task<ApiResponse> DeleteScheduleAsync(string id);
    }
}
