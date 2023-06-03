using Microsoft.AspNetCore.Identity;

namespace ServiceRadar.Infrastructure.Seeders;
public static class ServiceRadarSeederRoles
{
    private static readonly List<IdentityRole> _roleList = new()
    {
        new IdentityRole
        {
            Name = "user",
        },
        new IdentityRole
        {
            Name = "redactor",
        },
        new IdentityRole
        {
            Name = "admin",
        },
    };

    public static async Task Initialize(RoleManager<IdentityRole> roleManager)
    {
        foreach(var role in _roleList)
        {
            await roleManager.CreateAsync(role);
        }
    }
}
