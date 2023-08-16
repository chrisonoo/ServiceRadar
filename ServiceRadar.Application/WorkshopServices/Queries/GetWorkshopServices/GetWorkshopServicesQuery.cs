using MediatR;
using ServiceRadar.Application.WorkshopServices.Dtos;

namespace ServiceRadar.Application.WorkshopServices.Queries.GetWorkshopServices;
public class GetWorkshopServicesQuery : IRequest<IEnumerable<WorkshopServiceDto>>
{
    public string EncodedName { get; set; } = default!;
}
