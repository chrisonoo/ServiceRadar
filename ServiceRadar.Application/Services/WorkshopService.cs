using AutoMapper;

using ServiceRadar.Application.Workshops.Dtos;
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

    // TODO: move to MediatR
    public async Task<WorkshopDto?> GetByName(string name)
    {
        var workshop = await _serviceRadarRepository.GetByName(name);
        var workshopDto = _mapper.Map<WorkshopDto>(workshop);

        return workshopDto;
    }
}
