using TicketEase.Dtos.Users;
using TicketEase.Responses;

namespace TicketEase.Contracts
{
    public interface IUserService
    {
        public Task<ApiResponse> CreateUserAccount(CreateUserDto userDto);
        public Task<ApiResponse> CreateTravellerAccount(CreateTravellerDto userDto);
    }
}
