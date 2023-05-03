using ServiceRadar.Domain.Entities;

namespace ServiceRadar.Domain.Interfaces;
public interface IServiceRadarRepository
{
    Task CreateWorkshop(Workshop workshop);
    Task<IEnumerable<Workshop>> GetAllWorkshops();
    Task<Workshop> GetWorkshopByEncodedName(string encodedName);

    Task<Workshop?> GetWorkshopByName(string name);
}
