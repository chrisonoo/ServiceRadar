using AutoMapper;

using MediatR;

using ServiceRadar.Application.Workshops.Dtos;
using ServiceRadar.Domain.Interfaces;

namespace ServiceRadar.Application.Workshops.Queries.GetByName;
public class GetByNameQueryHandler : IRequestHandler<GetByNameQuery, WorkshopDto>
{
    private readonly IServiceRadarRepository _serviceRadarRepository;
    private readonly IMapper _mapper;

    public GetByNameQueryHandler(IServiceRadarRepository serviceRadarRepository, IMapper mapper)
    {
        _serviceRadarRepository = serviceRadarRepository;
        _mapper = mapper;
    }

    public async Task<WorkshopDto> Handle(GetByNameQuery request, CancellationToken cancellationToken)
    {
        var workshop = await _serviceRadarRepository.GetByName(request.Name);
        var workshopDto = _mapper.Map<WorkshopDto>(workshop);

        return workshopDto;
    }
}
