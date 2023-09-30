using AutoMapper;
using TicketEase.Dtos;
using TicketEase.Entities;

namespace TicketEase.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<CreateUserDto, User>().ReverseMap();
        }
    }
}
