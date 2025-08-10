using eShopApplicationOnWeb.Application.Contracts.Infrastructure.Identity.Services.Auth;
using eShopApplicationOnWeb.Application.Contracts.Infrastructure.Services.CurrentUser;
using eShopApplicationOnWeb.Infrastructure.Identity.Models;
using eShopApplicationOnWeb.Infrastructure.Identity.Persistence.Context;
using eShopApplicationOnWeb.Infrastructure.Identity.Security.Settings;
using eShopApplicationOnWeb.Infrastructure.Identity.Security.Tokens.Jwt;
using eShopApplicationOnWeb.Infrastructure.Identity.Services.Auth;
using eShopApplicationOnWeb.Infrastructure.Services.CurrentUser;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace eShopApplicationOnWeb.Infrastructure.Identity.Extensions
{
    public static class IdentityServiceExtensions
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationIdentityDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("IdentityDbConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;

                options.User.RequireUniqueEmail = true;
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_";
            })
            .AddEntityFrameworkStores<ApplicationIdentityDbContext>();

            services.AddScoped<IAuthService, AuthService>();

            services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

            AddJwtAuthentication(services, configuration);
            services.AddAuthorization();

            services.AddScoped<ICurrentUserService, CurrentUserService>();

            return services;
        }
        private static void AddJwtAuthentication(IServiceCollection services, IConfiguration configuration)
        {
            var jwtSettings = configuration.GetSection("JwtSettings").Get<JwtSettings>();
            var key = Encoding.UTF8.GetBytes(jwtSettings!.SecretKey);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = jwtSettings.Issuer,
                    ValidAudience = jwtSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                };
            });
        }
    }
}
