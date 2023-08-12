using ServiceRadar.Domain.Entities;
using ServiceRadar.Domain.Interfaces;
using ServiceRadar.Infrastructure.Data;

namespace ServiceRadar.Infrastructure.Repositories;
public class WorkshopServiceRepository : IWorkshopServiceRepository
{
    private readonly ServiceRadarDbContext _dbContext;

    public WorkshopServiceRepository(ServiceRadarDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Create(WorkshopService workshopService)
    {
        _dbContext.WorkshopServices.Add(workshopService);
        await _dbContext.SaveChangesAsync();
    }
}
