namespace ServiceRadar.Application.Common.ApplicationUser;
public class CurrentUser
{
    public CurrentUser(string id, string email, IEnumerable<string> roles)
    {
        Id = id;
        Email = email;
        Roles = roles;
    }

    public string Id { get; }
    public string Email { get; }
    public IEnumerable<string> Roles { get; }

    public bool IsInRole(string role) => Roles.Contains(role);
}
