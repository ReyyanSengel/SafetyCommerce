using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SafetyCommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafetyCommerce.Domain.EntityTypeBuilder
{
    public class QueryAppTypeBuilder : IEntityTypeConfiguration<QueryApp>
    {
        public void Configure(EntityTypeBuilder<QueryApp> builder)
        {
            builder.Property(x => x.Phone)
              .IsRequired()
              .HasColumnType("int")
              .HasMaxLength(11);
        }
    }
}
       

