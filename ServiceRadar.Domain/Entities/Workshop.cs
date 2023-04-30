namespace ServiceRadar.Domain.Entities;
public class Workshop
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    public string? About { get; set; }
    public DateTime CreateAt { get; set; } = DateTime.UtcNow;
    public WorkshopContactDetails ContactDetails { get; set; } = default!;
    public string EncodedName { get; private set; } = default!;

    public void EncodeName() => EncodedName = Name.ToLowerInvariant().Replace(" ", "-");
}
