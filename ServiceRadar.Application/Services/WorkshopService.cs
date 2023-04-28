using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ServiceRadar.Domain.Entities;
using ServiceRadar.Domain.Interfaces;

namespace ServiceRadar.Application.Services;
public class WorkshopService : IWorkshopService
{
    private readonly IServiceRadarRepository _workshopRepository;

    public WorkshopService(IServiceRadarRepository workshopRepository)
    {
        _workshopRepository = workshopRepository;
    }

    public async Task Create(Workshop workshop)
    {
        workshop.EncodeName();

        await _workshopRepository.Create(workshop);
    }
}
