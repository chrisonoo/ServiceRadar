using MediatR;
using ServiceRadar.Application.Common.ApplicationUser;
using ServiceRadar.Domain.Entities;
using ServiceRadar.Domain.Interfaces;

namespace ServiceRadar.Application.WorkshopServices.Commands;
public class CreateWorkshopServiceCommandHandler : IRequestHandler<CreateWorkshopServiceCommand>
{
    private readonly IServiceRadarRepository _repository;
    private readonly IUserContext _userContext;
    private readonly IWorkshopServiceRepository _workshopServiceRepository;

    public CreateWorkshopServiceCommandHandler(IServiceRadarRepository repository, IUserContext userContext, IWorkshopServiceRepository workshopServiceRepository)
    {
        _repository = repository;
        _userContext = userContext;
        _workshopServiceRepository = workshopServiceRepository;
    }

    public async Task Handle(CreateWorkshopServiceCommand request, CancellationToken cancellationToken)
    {
        var workshop = await _repository.GetWorkshopByEncodedName(request.WorkshopEncodedName!);

        var user = _userContext.GetCurrentUser();
        var isEditable = user != null && (workshop.CreateById == user.Id || user.IsInRole("Moderator") || user.IsInRole("Admin"));

        if(!isEditable)
        {
            return;
        }

        var workshopService = new WorkshopService()
        {
            Cost = request.Cost,
            Description = request.ServiceDescription,
            WorkshopId = workshop.Id,
        };

        await _workshopServiceRepository.Create(workshopService);

        return;
    }
}
