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
    public class ReceiverAppTypeBuilder : IEntityTypeConfiguration<ReceiverApp>
    {
        public void Configure(EntityTypeBuilder<ReceiverApp> builder)
        {
            builder.Property(x => x.NameSurname)
                .IsRequired()
                .HasColumnType("nvarchar")
                .HasMaxLength(256);

            builder.Property(x => x.ReceiverPhone)
               .IsRequired()
               .HasColumnType("int");
               
           



        }
    }
}
