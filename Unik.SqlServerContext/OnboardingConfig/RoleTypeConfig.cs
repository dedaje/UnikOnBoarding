using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unik.Onboarding.Domain.Model;

namespace Unik.SqlServerContext.OnboardingConfig;

public class RoleTypeConfig : IEntityTypeConfiguration<RoleEntity>
{
    public void Configure(EntityTypeBuilder<RoleEntity> builder)
    {
        builder.ToTable("Role", "role");
        builder.HasKey(x => x.RoleId);
    }
}