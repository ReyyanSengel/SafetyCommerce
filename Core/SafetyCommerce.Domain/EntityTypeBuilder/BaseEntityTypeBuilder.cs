using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SafetyCommerce.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafetyCommerce.Domain.EntityTypeBuilder
{
    public class BaseEntityTypeBuilder : IEntityTypeConfiguration<BaseEntity>
    {
        public void Configure(EntityTypeBuilder<BaseEntity> builder)
        {
            builder.Property(x => x.Personality)
                .HasColumnType("nvarchar");

            builder.Property(x => x.TCKN)
               .IsRequired()
               .HasColumnType("nvarchar")
               .HasMaxLength(256);

        }
    }
}



