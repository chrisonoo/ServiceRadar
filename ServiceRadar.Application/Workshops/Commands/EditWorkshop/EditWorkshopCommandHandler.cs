using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;

using ServiceRadar.Domain.Interfaces;

namespace ServiceRadar.Application.Workshops.Commands.EditWorkshop;
public class EditWorkshopCommandHandler : IRequestHandler<EditWorkshopCommand>
{
    private readonly IServiceRadarRepository _serviceRadarRepository;

    public EditWorkshopCommandHandler(IServiceRadarRepository serviceRadarRepository)
    {
        _serviceRadarRepository = serviceRadarRepository;
    }

    public async Task Handle(EditWorkshopCommand request, CancellationToken cancellationToken)
    {
        var workshop = await _serviceRadarRepository.GetWorkshopByEncodedName(request.EncodedName!);

        workshop.Description = request.Description;
        workshop.About = request.About;
        workshop.ContactDetails.Street = request.Street;
        workshop.ContactDetails.City = request.City;
        workshop.ContactDetails.PostalCode = request.PostalCode;
        workshop.ContactDetails.PhoneNumber = request.PhoneNumber;

        await _serviceRadarRepository.SaveToDatabase();

        return;
    }
}
