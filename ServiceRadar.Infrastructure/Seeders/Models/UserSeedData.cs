using Microsoft.AspNetCore.Identity;

namespace ServiceRadar.Infrastructure.Seeders.Models;
internal class UserSeedData
{
    public IdentityUser User { get; set; } = default!;
    public string Password { get; set; } = default!;
    public string Role { get; set; } = default!;
}
