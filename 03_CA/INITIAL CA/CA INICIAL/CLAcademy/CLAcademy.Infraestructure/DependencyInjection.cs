using CLAcademy.Application.Interfaces;
using CLAcademy.Infrastructure.Persistence;
using CLAcademy.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CLAcademy.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<AcademyDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("AcademyDB")));

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            return services;
        }
    }
}
