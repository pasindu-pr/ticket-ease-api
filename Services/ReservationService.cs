using AutoMapper;
using TicketEase.Contracts;
using TicketEase.Dtos.Reservation;
using TicketEase.Entities;
using TicketEase.Responses;

namespace TicketEase.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IRepository<Reservation> _repository;
        private readonly IRepository<Schedule> _scheduleRepository;
        private readonly IRepository<Train> _trainRepository;
        private readonly IMapper _mapper;

        public ReservationService(IRepository<Reservation> repository, IMapper mapper, IRepository<Schedule> scheduleRepository, IRepository<Train> trainRepository)
        {
            _repository = repository;
            _mapper = mapper;
            _scheduleRepository = scheduleRepository;
            _trainRepository = trainRepository;
        }
        public async Task<ApiResponse> CreateReservation(CreateReservationDto createReservation)
        {
            var scheduleId = createReservation.ScheduleId;
            var fromStationId = createReservation.FromStationId;
            var toStationId = createReservation.ToStationId;

            var scheudle = await _scheduleRepository.GetByIdAsync(scheduleId);
            var fromStation = await _trainRepository.GetByIdAsync(fromStationId);
            var toStation = await _trainRepository.GetByIdAsync(fromStationId);

            Reservation reservation = new();

            reservation.ScheduleId = scheudle.Id;
            reservation.UserId = "kdf";
            reservation.Price = 10;
            reservation.FromStationId = fromStation.Id;
            reservation.ToStationId = toStation.Id;

            await _repository.CreateAsync(reservation);

            ApiResponse apiResponse = new();
            apiResponse.Success = true;
            apiResponse.Message = "Reservation Created Successfully!";
            return apiResponse;
        }
    }
}
