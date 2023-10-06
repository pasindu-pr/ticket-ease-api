using AutoMapper;
using TicketEase.Dtos.Schedule;
using TicketEase.Dtos.Station;
using TicketEase.Dtos.Trains;
using TicketEase.Dtos.Users;
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
            CreateMap<CreateStationDto, Station>().ReverseMap();
            CreateMap<UpdateStationDto, Station>().ReverseMap();
            CreateMap<CreateScheduleDto, Schedule>().ReverseMap();
            CreateMap<UpdateScheduleDto, Schedule>().ReverseMap();
            CreateMap<GetScheduleDto, Schedule>().ReverseMap();
        }
    }
}
