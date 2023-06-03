using Microsoft.AspNetCore.Identity;

using ServiceRadar.Infrastructure.Seeders.Helpers;

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
            Role = "user",
        },
        new UserSeedData
        {
            User = new()
            {
                UserName = "redactor@test.com",
                Email = "redactor@test.com",
            },
            Password = "TEst!@12",
            Role= "redactor",
        },
        new UserSeedData
        {
            User = new()
            {
                UserName = "admin@test.com",
                Email = "admin@test.com",
            },
            Password = "TEst!@12",
            Role = "admin",
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
