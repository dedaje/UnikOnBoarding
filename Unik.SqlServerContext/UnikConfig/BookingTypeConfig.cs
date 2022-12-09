using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unik.Onboarding.Domain.Model;

namespace Unik.SqlServerContext.UnikConfig;

public class BookingTypeConfig : IEntityTypeConfiguration<BookingEntity>
{
    public void Configure(EntityTypeBuilder<BookingEntity> builder)
    {
        builder.ToTable("Booking", "booking");
        builder.HasKey(x => x.Id);
    }
}