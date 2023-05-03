using AutoMapper;

using MediatR;

using ServiceRadar.Application.Workshops.Dtos;
using ServiceRadar.Domain.Interfaces;

namespace ServiceRadar.Application.Workshops.Queries.GetWorkshopByEncodedName;
public class GetWorkshopByEncodedNameQueryHandler : IRequestHandler<GetWorkshopByEncodedNameQuery, WorkshopDto>
{
    private readonly IServiceRadarRepository _repository;
    private readonly IMapper _mapper;

    public GetWorkshopByEncodedNameQueryHandler(IServiceRadarRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<WorkshopDto> Handle(GetWorkshopByEncodedNameQuery request, CancellationToken cancellationToken)
    {
        var workshop = await _repository.GetWorkshopByEncodedName(request.EncodedName);
        var workshopDto = _mapper.Map<WorkshopDto>(workshop);

        return workshopDto;
    }
}
