using MediatR;

using ServiceRadar.Application.Workshops.Dtos;

namespace ServiceRadar.Application.Workshops.Queries.GetAllWorkshops;
public class GetAllWorkshopsQuery : IRequest<IEnumerable<WorkshopDto>>
{
}
