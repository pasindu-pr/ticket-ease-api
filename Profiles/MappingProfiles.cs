using AutoMapper;
using TicketEase.Dtos;
using TicketEase.Dtos.Trains;
using TicketEase.Entities;

namespace TicketEase.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<CreateUserDto, User>().ReverseMap();
            CreateMap<CreateTravellerDto, User>().ReverseMap();
            CreateMap<CreateTrainDto, Train>().ReverseMap();
            CreateMap<GetTrainDto, Train>().ReverseMap();
            CreateMap<UpdateTrainDto, Train>().ReverseMap();
        }
    }
}
