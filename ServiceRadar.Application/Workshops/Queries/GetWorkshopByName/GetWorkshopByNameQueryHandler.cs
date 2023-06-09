﻿using AutoMapper;

using MediatR;

using ServiceRadar.Application.Workshops.Dtos;
using ServiceRadar.Domain.Interfaces;

namespace ServiceRadar.Application.Workshops.Queries.GetWorkshopByName;
public class GetWorkshopByNameQueryHandler : IRequestHandler<GetWorkshopByNameQuery, WorkshopDto>
{
    private readonly IServiceRadarRepository _repository;
    private readonly IMapper _mapper;

    public GetWorkshopByNameQueryHandler(IServiceRadarRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<WorkshopDto> Handle(GetWorkshopByNameQuery request, CancellationToken cancellationToken)
    {
        var workshop = await _repository.GetWorkshopByName(request.Name);
        var workshopDto = _mapper.Map<WorkshopDto>(workshop);

        return workshopDto;
    }
}
