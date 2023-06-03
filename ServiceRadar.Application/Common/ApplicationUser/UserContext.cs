﻿using System.Security.Claims;

using Microsoft.AspNetCore.Http;

namespace ServiceRadar.Application.Common.ApplicationUser;
public class UserContext : IUserContext
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public UserContext(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public CurrentUser? GetCurrentUser()
    {
        var user = _httpContextAccessor?.HttpContext?.User;
        if(user == null)
        {
            throw new InvalidOperationException("Context user is not present");
        }

        if(user.Identity == null || !user.Identity.IsAuthenticated)
        {
            return null;
        }

        var id = user.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value;
        var email = user.FindFirst(c => c.Type == ClaimTypes.Email)!.Value;

        return new CurrentUser(id, email);
    }
}
