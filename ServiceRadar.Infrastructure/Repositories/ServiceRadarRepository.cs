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

    // TODO: Should I move this implementation to Workshop Service?
    public Task<Workshop?> GetByName(string name)
        => _dbContext.Workshops.FirstOrDefaultAsync(cw => cw.Name.ToLower() == name.ToLower());
}