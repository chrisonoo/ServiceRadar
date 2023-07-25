using MediatR;

using ServiceRadar.Application.Common.ApplicationUser;
using ServiceRadar.Domain.Interfaces;

namespace ServiceRadar.Application.Workshops.Commands.EditWorkshop;
public class EditWorkshopCommandHandler : IRequestHandler<EditWorkshopCommand>
{
    private readonly IServiceRadarRepository _repository;
    private readonly IUserContext _userContext;

    public EditWorkshopCommandHandler(IServiceRadarRepository repository, IUserContext userContext)
    {
        _repository = repository;
        _userContext = userContext;
    }

    public async Task Handle(EditWorkshopCommand request, CancellationToken cancellationToken)
    {
        var workshop = await _repository.GetWorkshopByEncodedName(request.EncodedName!);

        var user = _userContext.GetCurrentUser();
        var isEditable = user != null && (workshop.CreateById == user.Id || user.IsInRole("Moderator") || user.IsInRole("Admin"));

        if(!isEditable)
        {
            return;
        }

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
