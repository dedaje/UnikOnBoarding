using Microsoft.AspNetCore.Identity;

namespace Unik.WebApp.UserContext;

public class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}