using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity;

namespace ServiceRadar.Infrastructure.Seeders.Helpers;
internal class UserSeedData
{
    public IdentityUser User { get; set; } = default!;
    public string Password { get; set; } = default!;
}
