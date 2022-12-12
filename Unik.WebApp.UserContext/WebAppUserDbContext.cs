using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Unik.WebApp.UserContext;

public class WebAppUserDbContext : IdentityDbContext<ApplicationUser>
{
    public WebAppUserDbContext(DbContextOptions<WebAppUserDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        this.SeedUsers(builder);
        this.SeedUserClaims(builder);

        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }

    private void SeedUsers(ModelBuilder builder)
    {
        ApplicationUser user = new ApplicationUser()
        {
            Id = "b74ddd14-6340-4840-95c2-db12554843e5",
            FirstName = "John",
            LastName = "Doe",
            UserName = "admin@unik.dk",
            NormalizedUserName = "ADMIN@UNIK.DK",
            Email = "admin@unik.dk",
            NormalizedEmail = "ADMIN@UNIK.DK",
            LockoutEnabled = false,
            PhoneNumber = "12345678"
        };

        PasswordHasher<ApplicationUser> passwordHasher = new PasswordHasher<ApplicationUser>();
        user.PasswordHash = passwordHasher.HashPassword(user, "123456");

        builder.Entity<ApplicationUser>().HasData(user);
    }

    private void SeedUserClaims(ModelBuilder builder)
    {
        builder.Entity<IdentityUserClaim<string>>().HasData(
            new IdentityUserClaim<string>() { Id = 1, UserId = "b74ddd14-6340-4840-95c2-db12554843e5", ClaimType = "Admin", ClaimValue = "1"}
        );
    }
}
