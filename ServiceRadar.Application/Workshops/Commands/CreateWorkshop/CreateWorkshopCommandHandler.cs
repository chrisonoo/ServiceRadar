using AutoMapper;

using MediatR;

using ServiceRadar.Domain.Entities;
using ServiceRadar.Domain.Interfaces;

namespace ServiceRadar.Application.Workshops.Commands.CreateWorkshop;
public class CreateWorkshopCommandHandler : IRequestHandler<CreateWorkshopCommand>
{
    private readonly IServiceRadarRepository _repository;
    private readonly IMapper _mapper;

    public CreateWorkshopCommandHandler(IServiceRadarRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task Handle(CreateWorkshopCommand request, CancellationToken cancellationToken)
    {
        var workshop = _mapper.Map<Workshop>(request);
        workshop.EncodeName();

        await _repository.CreateWorkshop(workshop);

        return;
    }
}
