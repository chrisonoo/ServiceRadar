using ServiceRadar.Application.Workshops.Dtos;

namespace ServiceRadar.Application.Services;
public interface IWorkshopService
{
    Task<WorkshopDto?> GetByName(string name);
}