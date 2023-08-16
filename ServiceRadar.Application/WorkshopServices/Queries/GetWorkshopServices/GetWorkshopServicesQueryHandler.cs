using AutoMapper;
using MediatR;
using ServiceRadar.Application.WorkshopServices.Dtos;
using ServiceRadar.Domain.Interfaces;

namespace ServiceRadar.Application.WorkshopServices.Queries.GetWorkshopServices;
public class GetWorkshopServicesQueryHandler : IRequestHandler<GetWorkshopServicesQuery, IEnumerable<WorkshopServiceDto>>
{
    private readonly IWorkshopServiceRepository _workshopServiceRepository;
    private readonly IMapper _mapper;

    public GetWorkshopServicesQueryHandler(IWorkshopServiceRepository workshopServiceRepository, IMapper mapper)
    {
        _workshopServiceRepository = workshopServiceRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<WorkshopServiceDto>> Handle(GetWorkshopServicesQuery request, CancellationToken cancellationToken)
    {
        var services = await _workshopServiceRepository.GetAllServicesByEncodedName(request.EncodedName);
        var servicesDtos = _mapper.Map<IEnumerable<WorkshopServiceDto>>(services);

        return servicesDtos;
    }
}
