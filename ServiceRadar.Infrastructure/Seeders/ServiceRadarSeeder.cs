using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using ServiceRadar.Domain.Entities;
using ServiceRadar.Infrastructure.Data;

namespace ServiceRadar.Infrastructure.Seeders;
public static class ServiceRadarSeeder
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using var dbContext = new ServiceRadarDbContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<ServiceRadarDbContext>>());

        if(dbContext.Workshops.Any())
        {
            return;
        }

        ServiceRadarSeederWorkshops.Initialize(dbContext);

        dbContext.SaveChanges();
    }
}
