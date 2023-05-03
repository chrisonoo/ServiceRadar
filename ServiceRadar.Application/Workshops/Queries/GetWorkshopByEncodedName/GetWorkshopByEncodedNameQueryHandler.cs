using AutoMapper;

using MediatR;

using ServiceRadar.Application.Workshops.Dtos;
using ServiceRadar.Domain.Interfaces;

namespace ServiceRadar.Application.Workshops.Queries.GetWorkshopByEncodedName;
public class GetWorkshopByEncodedNameQueryHandler : IRequestHandler<GetWorkshopByEncodedNameQuery, WorkshopDto>
{
    private readonly IServiceRadarRepository _serviceRadarRepository;
    private readonly IMapper _mapper;

    public GetWorkshopByEncodedNameQueryHandler(IServiceRadarRepository serviceRadarRepository, IMapper mapper)
    {
        _serviceRadarRepository = serviceRadarRepository;
        _mapper = mapper;
    }
    public async Task<WorkshopDto> Handle(GetWorkshopByEncodedNameQuery request, CancellationToken cancellationToken)
    {
        var workshop = await _serviceRadarRepository.GetWorkshopByEncodedName(request.EncodedName);
        var workshopDto = _mapper.Map<WorkshopDto>(workshop);

        return workshopDto;
    }
}
