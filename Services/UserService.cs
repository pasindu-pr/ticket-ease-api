using AutoMapper;
using Serilog;
using TicketEase.Contracts;
using TicketEase.Dtos;
using TicketEase.Entities;

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

        public async Task CreateUserAccount(CreateUserDto userDto)
        {
            try
            {
                User user = _mapper.Map<User>(userDto);
                await _repository.CreateAsync(user);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                throw new Exception(ex.Message);
            }
        }
    }
}
