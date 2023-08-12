using MediatR;
using ServiceRadar.Application.WorkshopServices.Dtos;

namespace ServiceRadar.Application.WorkshopServices.Commands;
public class CreateWorkshopServiceCommand : WorkshopServiceDto, IRequest
{
    public string WorskhopEncodedName { get; set; } = default!;

}
