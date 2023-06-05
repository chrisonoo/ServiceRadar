using Microsoft.AspNetCore.Identity;

using ServiceRadar.Infrastructure.Seeders.Models;

namespace ServiceRadar.Infrastructure.Seeders;
public static class ServiceRadarSeederUsers
{
    private static readonly List<UserSeedData> _userList = new()
    {
        new UserSeedData
        {
            User = new()
            {
                UserName = "user@test.com",
                Email = "user@test.com",
            },
            Password = "TEst!@12",
            Role = "User",
        },
        new UserSeedData
        {
            User = new()
            {
                UserName = "user2@test.com",
                Email = "user2@test.com",
            },
            Password = "TEst!@12",
            Role = "User",
        },
        new UserSeedData
        {
            User = new()
            {
                UserName = "redactor@test.com",
                Email = "redactor@test.com",
            },
            Password = "TEst!@12",
            Role= "Redactor",
        },
        new UserSeedData
        {
            User = new()
            {
                UserName = "admin@test.com",
                Email = "admin@test.com",
            },
            Password = "TEst!@12",
            Role = "Admin",
        }
    };

    public static async Task Initialize(UserManager<IdentityUser> userManager)
    {
        foreach(var user in _userList)
        {
            await userManager.CreateAsync(user.User, user.Password);
            await userManager.AddToRoleAsync(user.User, user.Role);
        }
    }
}
