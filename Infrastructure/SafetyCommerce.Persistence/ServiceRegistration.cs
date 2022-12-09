using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SafetyCommerce.Application.Interfaces.IRepositorys;
using SafetyCommerce.Application.Interfaces.IUnitOfWorks;
using SafetyCommerce.Persistence.Context;
using SafetyCommerce.Persistence.Repositories;
using SafetyCommerce.Persistence.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafetyCommerce.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<SafetyCommerceDbContext>(
                options => options.UseSqlServer("name=ConnectionStrings:SqlConnection"));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ISupplierAppRepository, SupplierAppRepository>();
            services.AddScoped<IReceiverAppRepository, ReceiverAppRepository>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepsitory<>));
        }
    }
}
