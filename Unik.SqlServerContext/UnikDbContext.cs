using Microsoft.EntityFrameworkCore;
using Unik.Onboarding.Domain.Model;
using Unik.SqlServerContext.OnboardingConfig;

namespace Unik.SqlServerContext;

public class UnikDbContext : DbContext
{
    public UnikDbContext(DbContextOptions<UnikDbContext> options) : base(options)
    {
    }

    public DbSet<OnboardingEntity> OnboardingEntities { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder
            .ApplyConfiguration(new OnboardingTypeConfig());
    }
}