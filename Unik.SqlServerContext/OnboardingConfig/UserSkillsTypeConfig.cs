using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unik.Onboarding.Domain.Model;

namespace Unik.SqlServerContext.OnboardingConfig;

public class UserSkillsTypeConfig : IEntityTypeConfiguration<UserSkillsEntity>
{
    public void Configure(EntityTypeBuilder<UserSkillsEntity> builder)
    {
        builder.ToTable("UserSkills", "userSkills");
        builder.HasKey(x => x.Id);
    }
}