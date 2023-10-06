using AutoMapper;
using Serilog;
using TicketEase.Contracts;
using TicketEase.Dtos.Schedule;
using TicketEase.Dtos.Trains;
using TicketEase.Entities;
using TicketEase.Responses;

namespace TicketEase.Services
{
    public class ScheduleService : IScheduleService
    {
        private IMapper _mapper;
        private IRepository<Schedule> _repository;

        public ScheduleService(IMapper mapper, IRepository<Schedule> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<ApiResponse> AddScheduleAsync(CreateScheduleDto scheduleDto)
        {
            try
            {
                ApiResponse apiResponse = new();
                Schedule train = _mapper.Map<Schedule>(scheduleDto);
                await _repository.CreateAsync(train);
                apiResponse.Success = true;
                apiResponse.Message = "Schedule created successfully!";
                return apiResponse;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public async Task<ApiResponse> DeleteScheduleAsync(string id)
        {
            try
            {
                ApiResponse apiResponse = new();
                await _repository.DeleteAsync(id);
                apiResponse.Success = true;
                apiResponse.Message = "Schedule deleted successfully!";
                return apiResponse;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public async Task<ApiResponse> GetScheduleAsync(string id)
        {
            try
            {
                ApiResponse apiResponse = new();
                Schedule schedule = await _repository.GetByIdAsync(id);
                apiResponse.Success = true;
                apiResponse.Data = _mapper.Map<GetScheduleDto>(schedule);
                return apiResponse;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public async Task<ApiResponse> GetSchedulesAsync()
        {
            try
            {
                ApiResponse apiResponse = new();
                IReadOnlyCollection<Schedule> trains = await _repository.GetAllAsync();
                apiResponse.Success = true;
                apiResponse.Data = _mapper.Map<IReadOnlyCollection<GetScheduleDto>>(trains);
                return apiResponse;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public async Task<ApiResponse> UpdateScheduleAsync(string id, UpdateScheduleDto schedule)
        {
            try
            {
                ApiResponse apiResponse = new();
                Schedule train = _mapper.Map<Schedule>(schedule);
                await _repository.UpdateAsync(id, train);
                apiResponse.Success = true;
                apiResponse.Message = "Schedule updated successfully!";
                return apiResponse;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                throw new Exception(ex.Message);
            }
        }
    }
}
