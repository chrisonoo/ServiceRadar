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

    public async Task<IEnumerable<WorkshopDto>> GetAll()
    {
        var workshops = await _serviceRadarRepository.GetAll();
        var workshopDtos = _mapper.Map<IEnumerable<WorkshopDto>>(workshops);

        return workshopDtos;
    }

    public async Task<WorkshopDto?> GetByName(string name)
    {
        var workshop = await _serviceRadarRepository.GetByName(name);
        var workshopDto = _mapper.Map<WorkshopDto>(workshop);

        return workshopDto;
    }
}
