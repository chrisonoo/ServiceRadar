using AutoMapper;

using ServiceRadar.Application.Dtos;
using ServiceRadar.Domain.Entities;
using ServiceRadar.Domain.Interfaces;

namespace ServiceRadar.Application.Services;
public class WorkshopService : IWorkshopService
{
    private readonly IServiceRadarRepository _serviceRadarRepository;
    private readonly IMapper _mapper;

    public WorkshopService(IServiceRadarRepository serviceRadarRepository, IMapper mapper)
    {
        _serviceRadarRepository = serviceRadarRepository;
        _mapper = mapper;
    }

    public async Task Create(WorkshopDto workshopDto)
    {
        var workshop = _mapper.Map<Workshop>(workshopDto);
        workshop.EncodeName();

        await _serviceRadarRepository.Create(workshop);
    }
}
