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
    public DbSet<OnboardingUsersEntity> OnboardingUsersEntities { get; set; }
    public DbSet<RoleEntity> RoleEntities { get; set; }
    public DbSet<SkillsEntity> SkillsEntities { get; set; }
    public DbSet<UserEntity> UserEntities { get; set; }
    public DbSet<UserSkillsEntity> UserSkillsEntities { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new OnboardingTypeConfig());
        builder.ApplyConfiguration(new OnboardingUsersTypeConfig());
        builder.ApplyConfiguration(new RoleTypeConfig());
        builder.ApplyConfiguration(new SkillTypeConfig());
        builder.ApplyConfiguration(new UserTypeConfig());
        builder.ApplyConfiguration(new UserSkillsTypeConfig());
    }
}