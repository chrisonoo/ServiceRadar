using MediatR;

using ServiceRadar.Application.Workshops.Dtos;

namespace ServiceRadar.Application.Workshops.Queries.GetByName;
public class GetByNameQuery : IRequest<WorkshopDto>
{
    public GetByNameQuery(string name)
    {
        Name = name;
    }

    public string Name { get; }
}
