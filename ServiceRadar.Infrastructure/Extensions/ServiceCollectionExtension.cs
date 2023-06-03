using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using ServiceRadar.Domain.Interfaces;
using ServiceRadar.Infrastructure.Data;
using ServiceRadar.Infrastructure.Repositories;

namespace ServiceRadar.Infrastructure.Extensions;
public static class ServiceCollectionExtension
{
    /// <summary>
    ///     Extension method, registers the given context as a service in the <see cref="IServiceCollection" />.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection" /> to add services to.</param>
    /// <param name="configuration">Represents a set of key/value application configuration properties.</param>
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        // Add database service
        services.AddDbContext<ServiceRadarDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("ServiceRadar")));

        // Add Identity services
        services.AddDefaultIdentity<IdentityUser>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ServiceRadarDbContext>()
            .AddDefaultTokenProviders();

        // Add repository service
        services.AddScoped<IServiceRadarRepository, ServiceRadarRepository>();
    }
}
