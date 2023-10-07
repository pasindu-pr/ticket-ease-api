using AutoMapper;
using MongoDB.Driver;
using Serilog;
using TicketEase.Contracts;
using TicketEase.Dtos.Schedule;
using TicketEase.Entities;
using TicketEase.Responses;

namespace TicketEase.Services
{
    public class ScheduleService : IScheduleService
    {
        private IMapper _mapper;
        private IRepository<Schedule> _repository;
        private IRepository<Train> _trainRepository;
        private IRepository<Station> _stationRepository;

        public ScheduleService(IMapper mapper, IRepository<Schedule> repository, IRepository<Train> trainRepository, IRepository<Station> stationRepository)
        {
            _mapper = mapper;
            _repository = repository;
            _trainRepository = trainRepository;
            _stationRepository = stationRepository;
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

        public async Task<ApiResponse> AddStationsToSchedule(AddStationsToScheduleDto stationsToScheduleDto)
        {
            try
            {
                ApiResponse apiResponse = new();
                List<string> stationsIds = stationsToScheduleDto.Stations;
                string ScheduleId = stationsToScheduleDto.ScheduleId;

                Schedule schedule = await _repository.GetByIdAsync(ScheduleId);

                FilterDefinitionBuilder<Station> filterDef = new FilterDefinitionBuilder<Station>();
                var filter = filterDef.In(doc => doc.Id, stationsIds);
                IReadOnlyCollection<Station> stations = await _stationRepository.FilterAsync(filter);

                foreach (var station in stations)
                {
                    schedule.Stations.Add(station);
                }

                await _repository.UpdateAsync(ScheduleId, schedule);
                apiResponse.Success = true;
                apiResponse.Message = "Stations added to the schedule successfully!";
                return apiResponse;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public async Task<ApiResponse> AddTrainToSchedule(AddTrainToScheduleDto trainToScheduleDto)
        {
            try
            {
                ApiResponse apiResponse = new();
                string TrainId = trainToScheduleDto.TrainId;
                string ScheduleId = trainToScheduleDto.ScheduleId;

                Train train = await _trainRepository.GetByIdAsync(TrainId);

                if (train != null)
                {
                    Schedule schedule = await _repository.GetByIdAsync(ScheduleId);

                    if (schedule.Id != null)
                    {
                        schedule.Train = train;
                        await _repository.UpdateAsync(schedule.Id, schedule);

                        apiResponse.Success = true;
                        apiResponse.Message = "Train added to the schedule successfully!";
                    }
                    else
                    {
                        apiResponse.Success = false;
                        apiResponse.Message = "Schedule not found the given schedule id";
                    }
                }
                else
                {
                    apiResponse.Success = false;
                    apiResponse.Message = "Train not found the given schedule id";
                }
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
