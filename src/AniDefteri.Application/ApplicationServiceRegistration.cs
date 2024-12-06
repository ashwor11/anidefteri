using System.Reflection;
using AniDefteri.Application.Features.Families.Rules;
using Microsoft.Extensions.DependencyInjection;

namespace AniDefteri.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));


        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


        services.AddScoped<FamilyBusinessRules>();
        return services;
    }
}