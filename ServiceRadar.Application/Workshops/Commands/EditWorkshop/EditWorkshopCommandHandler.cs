using MediatR;

using ServiceRadar.Domain.Interfaces;

namespace ServiceRadar.Application.Workshops.Commands.EditWorkshop;
public class EditWorkshopCommandHandler : IRequestHandler<EditWorkshopCommand>
{
    private readonly IServiceRadarRepository _repository;

    public EditWorkshopCommandHandler(IServiceRadarRepository repository)
    {
        _repository = repository;
    }

    public async Task Handle(EditWorkshopCommand request, CancellationToken cancellationToken)
    {
        var workshop = await _repository.GetWorkshopByEncodedName(request.EncodedName!);

        workshop.Description = request.Description;
        workshop.About = request.About;
        workshop.ContactDetails.Street = request.Street;
        workshop.ContactDetails.City = request.City;
        workshop.ContactDetails.PostalCode = request.PostalCode;
        workshop.ContactDetails.PhoneNumber = request.PhoneNumber;

        await _repository.SaveToDatabase();

        return;
    }
}
