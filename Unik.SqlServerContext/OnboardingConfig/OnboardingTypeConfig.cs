using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unik.Onboarding.Domain.Model;

namespace Unik.SqlServerContext.OnboardingConfig;

public class OnboardingTypeConfig : IEntityTypeConfiguration<OnboardingEntity>
{
    public void Configure(EntityTypeBuilder<OnboardingEntity> builder)
    {
        builder.ToTable("Onboarding", "onboarding");
        builder.HasKey(x => x.ProjectId);
    }
}