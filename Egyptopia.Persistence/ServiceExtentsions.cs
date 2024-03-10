using Egyptopia.Application.Repositories;
using Egyptopia.Persistence.Context;
using Egyptopia.Persistence.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Egyptopia.Persistence
{
    public static class ServiceExtentsions
    {
        public static void ConfigurePersistance(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options=>options.UseSqlServer(configuration.GetConnectionString("SqlServerConnectionString")));
            services.AddDbContext<DataContext>();
            services.AddScoped<IGovernorateRepository,GovernorateRepository>();
        }
    }
}
