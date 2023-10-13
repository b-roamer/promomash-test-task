using Application.Interfaces;
using Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<ICountryRepository, CountryRepository>();
        services.AddScoped<IProvinceRepository, ProvinceRepository>();
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}