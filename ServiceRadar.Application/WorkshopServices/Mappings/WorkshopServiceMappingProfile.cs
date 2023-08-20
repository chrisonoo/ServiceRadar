using AutoMapper;
using ServiceRadar.Application.WorkshopServices.Dtos;
using ServiceRadar.Domain.Entities;

namespace ServiceRadar.Application.WorkshopServices.Mappings;
public class WorkshopServiceMappingProfile : Profile
{
    public WorkshopServiceMappingProfile()
    {
        CreateMap<WorkshopServiceDto, WorkshopService>()
            .ForMember(e => e.Description, opt => opt.MapFrom(src => src.ServiceDescription));

        CreateMap<WorkshopService, WorkshopServiceDto>()
            .ForMember(e => e.ServiceDescription, opt => opt.MapFrom(src => src.Description));
    }
}
