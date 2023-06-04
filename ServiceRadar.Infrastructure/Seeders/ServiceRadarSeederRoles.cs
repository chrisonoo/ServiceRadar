using Microsoft.AspNetCore.Identity;

namespace ServiceRadar.Infrastructure.Seeders;
public static class ServiceRadarSeederRoles
{
    private static readonly List<IdentityRole> _roleList = new()
    {
        new IdentityRole
        {
            Name = "User",
        },
        new IdentityRole
        {
            Name = "Redactor",
        },
        new IdentityRole
        {
            Name = "Admin",
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