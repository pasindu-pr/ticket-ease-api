using AutoMapper;
using Serilog;
using TicketEase.Contracts;
using TicketEase.Dtos;
using TicketEase.Entities;
using TicketEase.Responses;

namespace TicketEase.Services
{
    public class UserService : IUserService
    {
        private IMapper _mapper;
        private IRepository<User> _repository;

        public UserService(IMapper mapper, IRepository<User> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<ApiResponse> CreateTravellerAccount(CreateTravellerDto userDto)
        {
            ApiResponse apiResponse = new();
            try
            {
                User user = _mapper.Map<User>(userDto);
                User isDuplicatedNic = await _repository.FilterAsync(a => a.NicNumber == user.NicNumber);

                if (isDuplicatedNic == null)
                {
                    await _repository.CreateAsync(user);
                    apiResponse.Success = true;
                    apiResponse.Message = "Account Created Successfully!";
                    Log.Information($"Traveller account created. UserName: {user.FirstName}");
                }
                else
                {
                    apiResponse.Success = false;
                    apiResponse.Message = "User has already registered!";
                    Log.Error($"Traveller account creation failed. Duplicated NIC! UserName: {user.FirstName}");
                }
                return apiResponse;
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                throw new Exception(ex.Message);
            }
        }

        public async Task<ApiResponse> CreateUserAccount(CreateUserDto userDto)
        {
            ApiResponse apiResponse = new();
            try
            {
                User user = _mapper.Map<User>(userDto);
                await _repository.CreateAsync(user);
                apiResponse.Success = true;
                apiResponse.Message = "Account created successfully!";
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                throw new Exception(ex.Message);
            }
            return apiResponse;
        }
    }
}
