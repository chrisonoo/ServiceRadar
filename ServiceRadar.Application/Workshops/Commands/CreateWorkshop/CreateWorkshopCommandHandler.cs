using AutoMapper;

using MediatR;

using ServiceRadar.Domain.Entities;
using ServiceRadar.Domain.Interfaces;

namespace ServiceRadar.Application.Workshops.Commands.CreateWorkshop;
public class CreateWorkshopCommandHandler : IRequestHandler<CreateWorkshopCommand>
{
    private readonly IServiceRadarRepository _serviceRadarRepository;
    private readonly IMapper _mapper;

    public CreateWorkshopCommandHandler(IServiceRadarRepository serviceRadarRepository, IMapper mapper)
    {
        _serviceRadarRepository = serviceRadarRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(CreateWorkshopCommand request, CancellationToken cancellationToken)
    {
        var workshop = _mapper.Map<Workshop>(request);
        workshop.EncodeName();

        await _serviceRadarRepository.Create(workshop);

        return Unit.Value;
    }
}
