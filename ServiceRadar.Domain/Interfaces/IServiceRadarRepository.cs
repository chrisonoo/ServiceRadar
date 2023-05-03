using ServiceRadar.Domain.Entities;

namespace ServiceRadar.Domain.Interfaces;
public interface IServiceRadarRepository
{
    Task Create(Workshop workshop);
    Task<IEnumerable<Workshop>> GetAll();
    Task<Workshop?> GetByName(string name);
    Task<Workshop> GetWorkshopByEncodedName(string encodedName);
}
