using AutoMapper;
using ServiceRadar.Application.WorkshopServices.Dtos;
using ServiceRadar.Domain.Entities;

namespace ServiceRadar.Application.WorkshopServices.Mappings;
public class WorkshopServiceMappingProfile : Profile
{
    public WorkshopServiceMappingProfile()
    {
        CreateMap<WorkshopServiceDto, WorkshopService>()
            .ReverseMap();
    }
}
