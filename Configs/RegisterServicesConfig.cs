using Microsoft.ApplicationInsights.Extensibility;
using MongoDB.Driver;
using Serilog;
using TicketEase.Contracts;
using TicketEase.Repositories;
using TicketEase.Services;
using TicketEase.Settings;

namespace TicketEase.Configs
{
    public static class RegisterServicesConfig
    {
        public static void InjectServices(IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITrainService, TrainService>();
            services.AddScoped<IStationService, StationService>();
            services.AddScoped<IScheduleService, ScheduleService>();
            services.AddScoped<IReservationService, ReservationService>();

            services.AddSingleton(serviceProvider =>
            {
                var configuration = serviceProvider.GetService<IConfiguration>();
                var dbSettings = configuration.GetSection(nameof(DatabaseSettings)).Get<DatabaseSettings>();
                MongoClient mongoClient = new MongoClient(dbSettings.ConnectionString);
                return mongoClient.GetDatabase(dbSettings.DatabaseName);
            });

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            Log.Logger = new LoggerConfiguration().MinimumLevel.Information()
                .WriteTo.Console()
                .WriteTo.ApplicationInsights(TelemetryConfiguration.Active, TelemetryConverter.Traces).CreateLogger();
        }
    }
}
