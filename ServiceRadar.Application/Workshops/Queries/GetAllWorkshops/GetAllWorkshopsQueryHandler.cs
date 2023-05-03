using AutoMapper;

using MediatR;

using ServiceRadar.Application.Workshops.Dtos;
using ServiceRadar.Domain.Interfaces;

namespace ServiceRadar.Application.Workshops.Queries.GetAllWorkshops;
public class GetAllWorkshopsQueryHandler : IRequestHandler<GetAllWorkshopsQuery, IEnumerable<WorkshopDto>>
{
    private readonly IServiceRadarRepository _serviceRadarRepository;
    private readonly IMapper _mapper;

    public GetAllWorkshopsQueryHandler(IServiceRadarRepository serviceRadarRepository, IMapper mapper)
    {
        _serviceRadarRepository = serviceRadarRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<WorkshopDto>> Handle(GetAllWorkshopsQuery request, CancellationToken cancellationToken)
    {
        var workshops = await _serviceRadarRepository.GetAllWorkshops();
        var workshopDtos = _mapper.Map<IEnumerable<WorkshopDto>>(workshops);

        return workshopDtos;
    }
}
