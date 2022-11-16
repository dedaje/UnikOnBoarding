using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unik.Onboarding.Domain.Model;

namespace Unik.SqlServerContext.OnboardingConfig;

public class OnboardingUsersTypeConfig : IEntityTypeConfiguration<OnboardingUsersEntity>
{
    public void Configure(EntityTypeBuilder<OnboardingUsersEntity> builder)
    {
        builder.ToTable("OnboardingUsers", "onboardingUsers");
        builder.HasKey(x => x.Id);
    }
}