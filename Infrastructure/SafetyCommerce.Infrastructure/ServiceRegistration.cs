using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.DependencyInjection;
using SafetyCommerce.Application.Interfaces.IRepositorys;
using SafetyCommerce.Application.Interfaces.IServices;
using SafetyCommerce.Domain.Entities;
using SafetyCommerce.Infrastructure.Services;
using SafetyCommerce.Persistence.Context;
using SafetyCommerce.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafetyCommerce.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureService(this IServiceCollection services)
        {
            services.AddScoped<ISupplierAppService, SupplierAppService>();
            services.AddScoped<IReceiverAppService, ReceiverAppService>();
            services.AddScoped<IAuthenticatorService, AuthenticatorService>();
            services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));

            services.AddAuthentication();
            services.AddIdentity<AppUser, IdentityRole>(opt =>
            {
                opt.User.RequireUniqueEmail = true;
                opt.Password.RequireNonAlphanumeric = false;
            }).AddEntityFrameworkStores<SafetyCommerceDbContext>().AddDefaultTokenProviders();

            services.AddMvc(config =>
            {
                var policy = new AuthorizationPolicyBuilder()
                            .RequireAuthenticatedUser()
                            .Build();
                config.Filters.Add(new AuthorizeFilter(policy));

            });

            services.ConfigureApplicationCookie(opt =>
            {
                opt.LoginPath = "/Login/Index";
                opt.LogoutPath = "/Login/Logout";
                opt.Cookie = new CookieBuilder
                {
                    Name = "AspNetCoreIdentityREV",
                    HttpOnly = true,
                    SecurePolicy = CookieSecurePolicy.Always
                };

                opt.SlidingExpiration = true;
                opt.ExpireTimeSpan = TimeSpan.FromMinutes(60);
            });
        }
    }
}
