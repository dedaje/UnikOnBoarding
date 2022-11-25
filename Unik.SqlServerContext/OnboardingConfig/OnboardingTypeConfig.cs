using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unik.Onboarding.Domain.Model;

namespace Unik.SqlServerContext.OnboardingConfig;

public class OnboardingTypeConfig : IEntityTypeConfiguration<ProjectEntity>
{
    public void Configure(EntityTypeBuilder<ProjectEntity> builder)
    {
        builder.ToTable("Project", "project");
        builder.HasKey(x => x.Id);
    }
}