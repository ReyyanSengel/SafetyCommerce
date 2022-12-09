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
    public class SupplierAppTypeBuilder : IEntityTypeConfiguration<SupplierApp>
    {
        public  void Configure(EntityTypeBuilder<SupplierApp> builder)
        {
            builder.Property(x => x.NameSurname)
             .IsRequired()
             .HasColumnType("nvarchar")
             .HasMaxLength(256);

            builder.Property(x => x.SupplierEmail)
             .IsRequired()
             .HasColumnType("nvarchar")
             .HasMaxLength(50);

            builder.Property(x => x.ReceiverEmail)
             .IsRequired()
             .HasColumnType("nvarchar")
             .HasMaxLength(50);

            builder.Property(x => x.SupplierPhone)
             .IsRequired()
             .HasColumnType("int");

            builder.Property(x => x.ReceiverPhone)
             .IsRequired()
             .HasColumnType("int");

            builder.Property(x => x.SupplierIBAN)
             .IsRequired()
             .HasColumnType("nvarchar")
             .HasMaxLength(26);

            builder.Property(x => x.NumberPlate)
             .IsRequired()
             .HasColumnType("nvarchar")
             .HasMaxLength(8);

            builder.Property(x => x.Price)
             .IsRequired()
             .HasColumnType("decimal(18,2)");
             
        }
    }
}




             

