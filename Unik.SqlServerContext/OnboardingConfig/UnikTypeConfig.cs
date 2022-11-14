using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unik.Onboarding.Domain.Model;

namespace Unik.SqlServerContext.OnboardingConfig;

public class UnikTypeConfig : IEntityTypeConfiguration<OnboardingEntity>/*, IEntityTypeConfiguration<OnboardingUsersEntity>, IEntityTypeConfiguration<RoleEntity>,
                            IEntityTypeConfiguration<SkillsEntity>, IEntityTypeConfiguration<UserEntity>, IEntityTypeConfiguration<UserSkillsEntity>*/
{
    public void Configure(EntityTypeBuilder<OnboardingEntity> builder)
    {
        builder.ToTable("Onboarding", "onboarding");
        builder.HasKey(x => x.ProjectId);
    }

    /*public void Configure(EntityTypeBuilder<OnboardingUsersEntity> builder)
    {
        builder.ToTable("OnboardingUsers", "onboardingUsers");
        //builder.HasKey(x => x.Id);
    }

    public void Configure(EntityTypeBuilder<RoleEntity> builder)
    {
        builder.ToTable("Role", "role");
        builder.HasKey(x => x.RoleId);
    }

    public void Configure(EntityTypeBuilder<SkillsEntity> builder)
    {
        builder.ToTable("Skills", "skills");
        builder.HasKey(x => x.SkillId);
    }

    public void Configure(EntityTypeBuilder<UserEntity> builder)
    {
        builder.ToTable("Users", "users");
        builder.HasKey(x => x.UserId);
    }

    public void Configure(EntityTypeBuilder<UserSkillsEntity> builder)
    {
        builder.ToTable("UserSkills", "userSkills");
        //builder.HasKey(x => x.Id);
    }*/
}