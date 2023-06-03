namespace ServiceRadar.Application.Common.ApplicationUser;
public class CurrentUser
{
    public CurrentUser(string id, string email)
    {
        Id = id;
        Email = email;
    }

    public string Id { get; }
    public string Email { get; }
}
