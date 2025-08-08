using eShopApplicationOnWeb.Application.Contracts.Identity.Services.Auth;
using eShopApplicationOnWeb.Infrastructure.Identity.Persistence.Context;
using eShopApplicationOnWeb.Infrastructure.Identity.Persistence.Models;
using eShopApplicationOnWeb.Infrastructure.Identity.Services.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace eShopApplicationOnWeb.Infrastructure.Identity.Extensions
{
    public static class IdentityServiceExtensions
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationIdentityDbContext>(options =>
                options.UseNpgsql(
                    configuration.GetConnectionString("IdentityDbConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;

                options.User.RequireUniqueEmail = true;
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_";
            })
            .AddEntityFrameworkStores<ApplicationIdentityDbContext>()
            .AddDefaultTokenProviders();

            services.AddScoped<IAuthService, AuthService>();

            return services;
        }
    }
}
