using Egyptopia.Application.Repositories;
using Egyptopia.Persistence.Context;
using Egyptopia.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Egyptopia.Persistence
{
    public static class ServiceExtentsions
    {
        public static void ConfigurePersistance(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options => options.UseSqlServer(configuration.GetConnectionString("SqlServerConnectionString")));
            services.AddDbContext<DataContext>();
            services.AddScoped<IGovernorateRepository, GovernorateRepository>();
            services.AddScoped<IHotelRepository, HotelRepository>();
            services.AddScoped<IImageRepository, ImageRepository>();
            services.AddScoped<IPlaceRepository, PlaceRepository>();
            services.AddScoped<IRoomRepository, RoomRepository>();
            //services.AddScoped<IBookingRepository, BookingRepository>();
            services.AddScoped<ITourGuideRepository, TourGuideRepository>();
            services.AddScoped<ITourGuideServiceRepository, TourGuideServiceRepository>();
            services.AddScoped<IHotelCommentRepository, HotelCommentRepository>();
            services.AddScoped<ITourGuideCommentRepository, TourGuideCommentRepository>();
        }
    }
}