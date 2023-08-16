using ServiceRadar.Domain.Entities;

namespace ServiceRadar.Domain.Interfaces;
public interface IWorkshopServiceRepository
{
    Task Create(WorkshopService workshopService);
    Task<IEnumerable<WorkshopService>> GetAllServicesByEncodedName(string encodedName);
}
