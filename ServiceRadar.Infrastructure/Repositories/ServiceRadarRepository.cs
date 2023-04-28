using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
}
