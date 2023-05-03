using MediatR;

using ServiceRadar.Application.Workshops.Dtos;

namespace ServiceRadar.Application.Workshops.Queries.GetWorkshopByEncodedName;
public class GetWorkshopByEncodedNameQuery : IRequest<WorkshopDto>
{
    public GetWorkshopByEncodedNameQuery(string encodedName)
    {
        EncodedName = encodedName;
    }

    public string EncodedName { get; }
}
