using ServiceRadar.Application.Dtos;
using ServiceRadar.Domain.Entities;

namespace ServiceRadar.Application.Services;
public interface IWorkshopService
{
    Task Create(WorkshopDto workshopDto);
}