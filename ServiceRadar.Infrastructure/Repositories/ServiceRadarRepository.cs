using Microsoft.EntityFrameworkCore;

using ServiceRadar.Domain.Entities;
using ServiceRadar.Domain.Interfaces;
using ServiceRadar.Infrastructure.Data;

namespace ServiceRadar.Infrastructure.Repositories;
public class ServiceRadarRepository : IServiceRadarRepository
{
    private readonly ServiceRadarDbContext _dbContext;

    public ServiceRadarRepository(ServiceRadarDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task CreateWorkshop(Workshop workshop)
    {
        _dbContext.Add(workshop);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Workshop>> GetAllWorkshops()
        => await _dbContext.Workshops.ToListAsync();
    public async Task<Workshop> GetWorkshopByEncodedName(string encodedName)
        => await _dbContext.Workshops.FirstAsync(c => c.EncodedName == encodedName);

    public async Task<Workshop?> GetWorkshopByName(string name)
            => await _dbContext.Workshops.FirstOrDefaultAsync(cw => cw.Name.ToLower() == name.ToLower());

    public async Task SaveToDatabase()
        => await _dbContext.SaveChangesAsync();
}