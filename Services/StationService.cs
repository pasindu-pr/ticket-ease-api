using AutoMapper;
using Serilog;
using TicketEase.Contracts;
using TicketEase.Dtos.Station;
using TicketEase.Entities;
using TicketEase.Responses;

namespace TicketEase.Services
{
    public class StationService : IStationService
    {
        private IMapper _mapper;
        private IRepository<Station> _repository;

        public StationService(IMapper mapper, IRepository<Station> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<ApiResponse> CreateStation(CreateStationDto stationDto)
        {
            try
            {
                ApiResponse apiResponse = new();
                Station station = _mapper.Map<Station>(stationDto);
                await _repository.CreateAsync(station);
                apiResponse.Success = true;
                apiResponse.Message = "Station created successfully!";
                return apiResponse;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public async Task<ApiResponse> DeleteStation(string id)
        {
            try
            {
                ApiResponse apiResponse = new();
                await _repository.DeleteAsync(id);
                apiResponse.Success = true;
                apiResponse.Message = "Station deleted successfully!";
                return apiResponse;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public async Task<ApiResponse> GetStations()
        {
            try
            {
                ApiResponse apiResponse = new();
                IReadOnlyCollection<Station> stations = await _repository.GetAllAsync();
                apiResponse.Success = true;
                apiResponse.Data = _mapper.Map<IReadOnlyCollection<GetStationDto>>(stations);
                return apiResponse;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public async Task<ApiResponse> GetStation(string id)
        {
            try
            {
                ApiResponse apiResponse = new();
                Station station = await _repository.GetByIdAsync(id);
                apiResponse.Success = true;
                apiResponse.Data = _mapper.Map<GetStationDto>(station);
                return apiResponse;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public async Task<ApiResponse> UpdateStation(string id, UpdateStationDto stationDto)
        {
            try
            {
                ApiResponse apiResponse = new();
                Station train = _mapper.Map<Station>(stationDto);
                await _repository.UpdateAsync(id, train);
                apiResponse.Success = true;
                apiResponse.Message = "Station updated successfully!";
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
