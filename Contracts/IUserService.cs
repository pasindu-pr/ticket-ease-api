using TicketEase.Dtos;
using TicketEase.Entities;

namespace TicketEase.Contracts
{
    public interface IUserService
    {
        public Task CreateUserAccount(CreateUserDto userDto);
    }
}
