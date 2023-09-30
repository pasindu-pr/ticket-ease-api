using AutoMapper;
using Serilog;
using TicketEase.Contracts;
using TicketEase.Dtos.Trains;
using TicketEase.Entities;
using TicketEase.Responses;

namespace TicketEase.Services
{
    public class TrainService : ITrainService
    {
        private IMapper _mapper;
        private IRepository<Train> _repository;

        public TrainService(IMapper mapper, IRepository<Train> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<ApiResponse> CreateTrain(CreateTrainDto trainDto)
        {
            try
            {
                ApiResponse apiResponse = new();
                Train train = _mapper.Map<Train>(trainDto);
                await _repository.CreateAsync(train);
                apiResponse.Success = true;
                apiResponse.Message = "Train created successfully!";
                return apiResponse;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public async Task<ApiResponse> DeleteTrain(string id)
        {
            try
            {
                ApiResponse apiResponse = new();
                await _repository.DeleteAsync(id);
                apiResponse.Success = true;
                apiResponse.Message = "Train deleted successfully!";
                return apiResponse;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public async Task<ApiResponse> GetTrain(string id)
        {
            try
            {
                ApiResponse apiResponse = new();
                Train train = await _repository.GetByIdAsync(id);
                apiResponse.Success = true;
                apiResponse.Data = _mapper.Map<GetTrainDto>(train);
                return apiResponse;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public async Task<ApiResponse> GetTrains()
        {
            try
            {
                ApiResponse apiResponse = new();
                IReadOnlyCollection<Train> trains = await _repository.GetAllAsync();
                apiResponse.Success = true;
                apiResponse.Data = _mapper.Map<IReadOnlyCollection<GetTrainDto>>(trains);
                return apiResponse;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public async Task<ApiResponse> UpdateTrain(string id, UpdateTrainDto trainDto)
        {
            try
            {
                ApiResponse apiResponse = new();
                Train train = _mapper.Map<Train>(trainDto);
                await _repository.UpdateAsync(id, train);
                apiResponse.Success = true;
                apiResponse.Message = "Train updated successfully!";
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
