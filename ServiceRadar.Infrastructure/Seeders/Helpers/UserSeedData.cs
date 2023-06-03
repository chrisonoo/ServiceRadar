using Microsoft.AspNetCore.Identity;

namespace ServiceRadar.Infrastructure.Seeders.Helpers;
internal class UserSeedData
{
    public IdentityUser User { get; set; } = default!;
    public string Password { get; set; } = default!;
}
