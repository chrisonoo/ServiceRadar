using ServiceRadar.Application.Dtos;

namespace ServiceRadar.Application.Services;
public interface IWorkshopService
{
    Task Create(WorkshopDto workshopDto);
    Task<IEnumerable<WorkshopDto>> GetAll();
}