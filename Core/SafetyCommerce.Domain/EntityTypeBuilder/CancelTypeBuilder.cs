using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SafetyCommerce.Domain.Entities;

namespace SafetyCommerce.Domain.EntityTypeBuilder
{
    public class CancelTypeBuilder : IEntityTypeConfiguration<CancelApp>
    {
        public void Configure(EntityTypeBuilder<CancelApp> builder)
        {
            builder.Property(x => x.Phone)
                .IsRequired()
                .HasColumnType("int")
                .HasMaxLength(11);
        }
    }
}
