using ServiceRadar.Domain.Entities;
using ServiceRadar.Infrastructure.Data;

namespace ServiceRadar.Infrastructure.Seeders;
public class ServiceRadarSeederWorkshopServices
{
    private static readonly List<WorkshopService> _workshopServiceSeedDataList = new()
    {
        new WorkshopService
        {
            Description = "Tires swap",
            Cost = "300",
            WorkshopId = 1,
        },
        new WorkshopService
        {
            Description = "Oil change",
            Cost = "450",
            WorkshopId = 1,
        },
        new WorkshopService
        {
            Description = "Technical review",
            Cost = "250",
            WorkshopId = 1,
        },
        new WorkshopService
        {
            Description = "Rear wishbone repair",
            Cost = "250",
            WorkshopId = 2,
        },
        new WorkshopService
        {
            Description = "Glow plugs replacement",
            Cost = "900",
            WorkshopId = 2,
        },
    };

    public static async Task Initialize(ServiceRadarDbContext dbContext)
    {
        foreach(var workshopService in _workshopServiceSeedDataList)
        {
            await dbContext.WorkshopServices.AddAsync(workshopService);
        }
    }
}
