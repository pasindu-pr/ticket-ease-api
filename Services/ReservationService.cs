using AutoMapper;
using MongoDB.Driver;
using TicketEase.Contracts;
using TicketEase.Dtos.Reservation;
using TicketEase.Entities;
using TicketEase.Responses;
using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace TicketEase.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IRepository<Reservation> _repository;
        private readonly IRepository<Schedule> _scheduleRepository;
        private readonly IRepository<Train> _trainRepository;
        private readonly IRepository<Station> _stationRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;


        public ReservationService(IRepository<Reservation> repository, IMapper mapper, IRepository<Schedule> scheduleRepository, IRepository<Train> trainRepository, IRepository<Station> stationRepository, IHttpContextAccessor httpContextAccessor)
        {
            _repository = repository;
            _mapper = mapper;
            _scheduleRepository = scheduleRepository;
            _trainRepository = trainRepository;
            _stationRepository = stationRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<ApiResponse> GetReservations()
        {
            ApiResponse response = new ApiResponse();

            var userId = _httpContextAccessor.HttpContext.User.Identities.First().Claims.First().Value;


            FilterDefinitionBuilder<Reservation> filterDef = new FilterDefinitionBuilder<Reservation>();
            var filter = filterDef.Eq(doc => doc.UserId, userId) & filterDef.Eq(doc => doc.IsCancelled, false);

            IReadOnlyCollection<Reservation> reservations = await _repository.FilterAsync(filter);
            response.Data = _mapper.Map<IReadOnlyCollection<GetReservationsDto>>(reservations);
            response.Success = true;

            return response;
        }

        public async Task<ApiResponse> CreateReservation(CreateReservationDto createReservation)
        {
            var scheduleId = createReservation.ScheduleId;
            var fromStationId = createReservation.FromStationId;
            var toStationId = createReservation.ToStationId;
            var userId = _httpContextAccessor.HttpContext!.User.Identities.First().Claims.First().Value;

            var scheudle = await _scheduleRepository.GetByIdAsync(scheduleId);
            var fromStation = await _stationRepository.GetByIdAsync(fromStationId);
            var toStation = await _stationRepository.GetByIdAsync(toStationId);

            Reservation reservation = new();

            reservation.ScheduleId = scheudle.Id;
            reservation.UserId = userId;
            reservation.Price = 10;
            reservation.FromStationId = fromStation.Id;
            reservation.ToStationId = toStation.Id;
            reservation.PassengerCount = createReservation.PassengerCount;

            await _repository.CreateAsync(reservation);

            ApiResponse apiResponse = new();
            apiResponse.Success = true;
            apiResponse.Message = "Reservation Created Successfully!";
            return apiResponse;
        }

        public async Task<ApiResponse> GetCancelledReservations()
        {
            ApiResponse response = new ApiResponse();

            var userId = _httpContextAccessor.HttpContext.User.Identities.First().Claims.First().Value;

            FilterDefinitionBuilder<Reservation> filterDef = new FilterDefinitionBuilder<Reservation>();
            var filter = filterDef.Eq(doc => doc.UserId, userId) & filterDef.Eq(doc => doc.IsCancelled, true);

            IReadOnlyCollection<Reservation> reservations = await _repository.FilterAsync(filter);
            response.Data = _mapper.Map<IReadOnlyCollection<GetReservationsDto>>(reservations);
            response.Success = true;

            return response;
        }

        public async Task<ApiResponse> DeleteReservation(string reservationId)
        {
            ApiResponse response = new ApiResponse();

            var userId = _httpContextAccessor.HttpContext.User.Identities.First().Claims.First().Value;


            Reservation reservation = await _repository.GetByIdAsync(reservationId);
            reservation.IsCancelled = true;

            response.Success = true;
            return response;
        }
    }
}
