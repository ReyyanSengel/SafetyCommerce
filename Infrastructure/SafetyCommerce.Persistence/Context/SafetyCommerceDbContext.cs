using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SafetyCommerce.Domain.Entities;
using SafetyCommerce.Domain.EntityTypeBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafetyCommerce.Persistence.Context
{
    public class SafetyCommerceDbContext : IdentityDbContext<AppUser, IdentityRole, string>
    {
        public SafetyCommerceDbContext(DbContextOptions<SafetyCommerceDbContext> options) : base(options)
        {
        }
        public DbSet<ReceiverApp> ReceiverApps { get; set; }
        public DbSet<SupplierApp> SupplierApps { get; set; }
        public DbSet<QueryApp> QueryApps { get; set; }
        public DbSet<CancelApp> CancelApps { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
               .ApplyConfiguration(new ReceiverAppTypeBuilder())
               .ApplyConfiguration(new SupplierAppTypeBuilder())
               .ApplyConfiguration(new QueryAppTypeBuilder())
               .ApplyConfiguration(new CancelTypeBuilder());
            base.OnModelCreating(builder);
        }

    }
}
