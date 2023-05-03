using MediatR;

using ServiceRadar.Application.Workshops.Dtos;

namespace ServiceRadar.Application.Workshops.Queries.GetWorkshopByName;
public class GetWorkshopByNameQuery : IRequest<WorkshopDto>
{
    public GetWorkshopByNameQuery(string name)
    {
        Name = name;
    }

    public string Name { get; }
}
