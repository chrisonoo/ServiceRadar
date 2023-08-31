using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using ServiceRadar.Infrastructure.Data;

namespace ServiceRadar.Infrastructure.Seeders;
public static class ServiceRadarSeeder
{
    public static async Task SeedSampleDataAsync(IServiceProvider services)
    {
        using(var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>())
        {
            if(await roleManager.FindByNameAsync("user") == null)
            {
                await ServiceRadarSeederRoles.Initialize(roleManager);
            }
        }

        using(var userManager = services.GetRequiredService<UserManager<IdentityUser>>())
        {
            if(await userManager.FindByEmailAsync("user@test.com") == null)
            {
                await ServiceRadarSeederUsers.Initialize(userManager);
            }
        }

        using(var dbContext = new ServiceRadarDbContext(
            services.GetRequiredService<DbContextOptions<ServiceRadarDbContext>>()))
        {
            if(!dbContext.Workshops.Any())
            {
                await ServiceRadarSeederWorkshops.Initialize(dbContext);
                dbContext.SaveChanges();
            }
        }

        using(var dbContext = new ServiceRadarDbContext(
            services.GetRequiredService<DbContextOptions<ServiceRadarDbContext>>()))
        {
            if(!dbContext.WorkshopServices.Any())
            {
                await ServiceRadarSeederWorkshopServices.Initialize(dbContext);
                dbContext.SaveChanges();
            }
        }
    }
}
