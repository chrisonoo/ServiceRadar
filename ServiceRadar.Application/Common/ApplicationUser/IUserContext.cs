namespace ServiceRadar.Application.Common.ApplicationUser;

public interface IUserContext
{
    CurrentUser? GetCurrentUser();
}