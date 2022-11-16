using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unik.Onboarding.Domain.Model;

namespace Unik.SqlServerContext.OnboardingConfig;

public class SkillTypeConfig : IEntityTypeConfiguration<SkillsEntity>
{
    public void Configure(EntityTypeBuilder<SkillsEntity> builder)
    {
        builder.ToTable("Skills", "skills");
        builder.HasKey(x => x.SkillId);
    }
}