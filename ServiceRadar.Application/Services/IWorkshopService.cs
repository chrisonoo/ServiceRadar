using ServiceRadar.Domain.Entities;

namespace ServiceRadar.Application.Services;
public interface IWorkshopService
{
    Task Create(Workshop workshop);
}