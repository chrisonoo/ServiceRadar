using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ServiceRadar.Domain.Entities;
using ServiceRadar.Infrastructure.Data;

namespace ServiceRadar.Infrastructure.Seeders;
public class ServiceRadarSeeder
{
    private readonly ServiceRadarDbContext _dbContext;

    public ServiceRadarSeeder(ServiceRadarDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Seed()
    {
        if(await _dbContext.Database.CanConnectAsync())
        {
            if(!_dbContext.Workshops.Any())
            {
                var workshop = new Workshop()
                {
                    Name = "Mazda Service Center",
                    Description = "Authorized Mazda service center",
                    ContactDetails = new()
                    {
                        City = "Sandefjord",
                        Street = "Gjekstadveien 2",
                        PostalCode = "3218",
                        PhoneNumber = "+47 33 45 43 00"
                    }
                };
                workshop.EncodeName();

                _dbContext.Workshops.Add(workshop);
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
