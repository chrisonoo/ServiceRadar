using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using ServiceRadar.Domain.Interfaces;
using ServiceRadar.Infrastructure.Data;
using ServiceRadar.Infrastructure.Repositories;
using ServiceRadar.Infrastructure.Seeders;

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
        services.AddDbContext<ServiceRadarDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("ServiceRadar")));

        services.AddScoped<IServiceRadarRepository, ServiceRadarRepository>();
    }
}
