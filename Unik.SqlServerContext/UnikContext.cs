using Microsoft.EntityFrameworkCore;
using Unik.Onboarding.Domain.Model;
using Unik.SqlServerContext.OnboardingConfig;

namespace Unik.SqlServerContext;

public class UnikContext : DbContext
{
    public UnikContext(DbContextOptions<UnikContext> options) : base(options)
    {
        
    }

    public DbSet<OnboardingEntity> OnboardingEntities { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder
            .ApplyConfiguration(new OnboardingTypeConfig());
    }
}