using AutoMapper;

using MediatR;

using ServiceRadar.Application.Common.ApplicationUser;
using ServiceRadar.Domain.Entities;
using ServiceRadar.Domain.Interfaces;

namespace ServiceRadar.Application.Workshops.Commands.CreateWorkshop;
public class CreateWorkshopCommandHandler : IRequestHandler<CreateWorkshopCommand>
{
    private readonly IServiceRadarRepository _repository;
    private readonly IMapper _mapper;
    private readonly IUserContext _userContext;

    public CreateWorkshopCommandHandler(IServiceRadarRepository repository, IMapper mapper, IUserContext userContext)
    {
        _repository = repository;
        _mapper = mapper;
        _userContext = userContext;
    }

    public async Task Handle(CreateWorkshopCommand request, CancellationToken cancellationToken)
    {
        var currentUser = _userContext.GetCurrentUser();
        if(currentUser == null || !currentUser.IsInRole("User"))
        {
            return;
        }

        var workshop = _mapper.Map<Workshop>(request);
        workshop.EncodeName();

        workshop.CreateById = currentUser.Id;

        await _repository.CreateWorkshop(workshop);

        return;
    }
}
