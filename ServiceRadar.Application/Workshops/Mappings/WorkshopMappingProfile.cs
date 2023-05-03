using AutoMapper;

using ServiceRadar.Application.Workshops.Commands.EditWorkshop;
using ServiceRadar.Application.Workshops.Dtos;
using ServiceRadar.Domain.Entities;

namespace ServiceRadar.Application.Workshops.Mappings;
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

        CreateMap<Workshop, WorkshopDto>()
            .ForMember(dto => dto.PhoneNumber, opt => opt.MapFrom(src => src.ContactDetails.PhoneNumber))
            .ForMember(dto => dto.Street, opt => opt.MapFrom(src => src.ContactDetails.Street))
            .ForMember(dto => dto.City, opt => opt.MapFrom(src => src.ContactDetails.City))
            .ForMember(dto => dto.PostalCode, opt => opt.MapFrom(src => src.ContactDetails.PostalCode));

        CreateMap<WorkshopDto, EditWorkshopCommand>();
    }
}
