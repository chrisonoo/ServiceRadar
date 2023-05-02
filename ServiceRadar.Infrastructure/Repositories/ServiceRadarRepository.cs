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

    public async Task Create(Workshop workshop)
    {
        _dbContext.Add(workshop);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Workshop>> GetAll()
        => await _dbContext.Workshops.ToListAsync();

    public async Task<Workshop?> GetByName(string name)
        => await _dbContext.Workshops.FirstOrDefaultAsync(cw => cw.Name.ToLower() == name.ToLower());
}