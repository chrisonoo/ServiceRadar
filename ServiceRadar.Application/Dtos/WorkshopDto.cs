using System.ComponentModel.DataAnnotations;

namespace ServiceRadar.Application.Dtos;
public class WorkshopDto
{
    [Required(ErrorMessage = "Field is required")]
    [StringLength(20, MinimumLength = 2, ErrorMessage = "Length: min. 2, max. 20")]
    public string Name { get; set; } = default!;
    [Required(ErrorMessage = "Field is required")]
    public string? Description { get; set; }
    public string? About { get; set; }
    [StringLength(16, MinimumLength = 8, ErrorMessage = "Length: min. 8, max. 16")]
    public string? PhoneNumber { get; set; }
    public string? Street { get; set; }
    public string? City { get; set; }
    public string? PostalCode { get; set; }
    public string? EncodedName { get; set; }
}
