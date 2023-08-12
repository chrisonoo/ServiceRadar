namespace ServiceRadar.Domain.Entities;
public class WorkshopService
{
    public int Id { get; set; }
    public string Description { get; set; } = default!;
    public string Cost { get; set; } = default!;

    public int WorkshopId { get; set; } = default!;
    public Workshop Workshop { get; set; } = default!;
}
