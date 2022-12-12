using Microsoft.EntityFrameworkCore;
using Unik.Onboarding.Domain.Model;
using Unik.SqlServerContext.UnikConfig;

namespace Unik.SqlServerContext;

public class UnikDbContext : DbContext
{
    public UnikDbContext(DbContextOptions<UnikDbContext> options) : base(options)
    {

    }

    public DbSet<ProjectEntity> ProjectEntities { get; set; }
    public DbSet<UsersEntity> UserEntities { get; set; }
    public DbSet<BookingEntity> BookingEntities { get; set; }
    //public DbSet<RoleEntity> RoleEntities { get; set; }
    //public DbSet<SkillsEntity> SkillsEntities { get; set; }
    public DbSet<TaskEntity> TaskEntities { get; set; }
    //public DbSet<UserEntity> UserEntities { get; set; }
    //public DbSet<UserSkillsEntity> UserSkillsEntities { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder
            .ApplyConfiguration(new ProjectTypeConfig())
            .ApplyConfiguration(new UserTypeConfig())
            .ApplyConfiguration(new BookingTypeConfig())
            .ApplyConfiguration(new TaskTypeConfig());

        builder.Entity<ProjectEntity>()
            .HasMany<UsersEntity>(u => u.Users)
            .WithMany(p => p.Projects);

        builder.Entity<BookingEntity>().HasData(new BookingEntity(1, DateTime.Parse("2 December 2023"), false, null));
        builder.Entity<UsersEntity>().HasData(new UsersEntity(1, "admin@unik.dk"));

        //builder.ApplyConfiguration(new UserTypeConfig());
        //builder.ApplyConfiguration(new RoleTypeConfig());
        //builder.ApplyConfiguration(new SkillTypeConfig());
        //builder.ApplyConfiguration(new TaskTypeConfig());
        //builder.ApplyConfiguration(new UserTypeConfig());
        //builder.ApplyConfiguration(new UserSkillsTypeConfig());
    }
}