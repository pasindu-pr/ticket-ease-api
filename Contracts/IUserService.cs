using TicketEase.Dtos.Users;
using TicketEase.Responses;

namespace TicketEase.Contracts
{
    public interface IUserService
    {
        public Task<ApiResponse> CreateUserAccount(CreateUserDto userDto);
        public Task<ApiResponse> CreateTravellerAccount(CreateTravellerDto userDto);
        public Task<ApiResponse> LoginAsync(LoginUserDto userLoginDto);
        public bool ValidateToken(string token);
        public Task<ApiResponse> DeactivateAccout();
        public Task<ApiResponse> ActivateAccount(ActivateUserAccountDto user);
        public Task<ApiResponse> GetAllTravellers();
    }
}
