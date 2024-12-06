using AniDefteri.Application.Services.Interfaces;
using AniDefteri.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;

namespace AniDefteri.Persistence
{
    public static class PersistenceServiceRegistration 
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AniDefteriDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IFamilyRepository, FamilyRepository>();


            return services;
        }
    }
}
