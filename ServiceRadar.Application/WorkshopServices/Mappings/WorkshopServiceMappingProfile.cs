using AutoMapper;
using ServiceRadar.Application.WorkshopServices.Dtos;

namespace ServiceRadar.Application.WorkshopServices.Mappings;
public class WorkshopServiceMappingProfile : Profile
{
    public WorkshopServiceMappingProfile()
    {
        CreateMap<WorkshopServiceDto, WorkshopServiceDto>()
            .ReverseMap();
    }
}
