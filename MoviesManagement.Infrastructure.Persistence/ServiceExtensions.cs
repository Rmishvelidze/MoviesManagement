using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MoviesManagement.Core.Application.Interfaces;
using MoviesManagement.Infrastructure.Persistence.Implementations;

namespace MoviesManagement.Infrastructure.Persistence
{
    public static class ServiceExtensions
    {
        public static void AddPersistenceLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddDbContext<DataContext>(options => options.UseSqlServer(configuration.GetConnectionString("MovieConnection"))); ;
        }
    }
}
