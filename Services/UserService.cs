using AutoMapper;
using TicketEase.Contracts;
using TicketEase.Dtos;
using TicketEase.Entities;

namespace TicketEase.Services
{
    public class UserService : IUserService
    {
        private IMapper _mapper;
        public IRepository<User> _repository;

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
                throw new Exception(ex.Message);
            }
        }
    }
}
