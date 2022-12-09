using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using SafetyCommerce.Application.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafetyCommerce.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationService(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MapProfile));
            //services.AddValidatorsFromAssemblyContaining(typeof());

        }
    }
}
