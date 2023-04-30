using AutoMapper;

using ServiceRadar.Application.Dtos;
using ServiceRadar.Domain.Entities;

namespace ServiceRadar.Application.Mappings;
public class WorkshopMappingProfile : Profile
{
    public WorkshopMappingProfile()
    {
        CreateMap<WorkshopDto, Workshop>()
            .ForMember(e => e.ContactDetails, opt => opt.MapFrom(src => new WorkshopContactDetails()
            {
                City = src.City,
                PhoneNumber = src.PhoneNumber,
                PostalCode = src.PostalCode,
                Street = src.Street,
            }));
    }
}
