using ServiceRadar.Domain.Entities;

namespace ServiceRadar.Infrastructure.Seeders.Models;
internal class WorkshopSeedData : Workshop
{
    public string UserName { get; set; } = default!;
}
