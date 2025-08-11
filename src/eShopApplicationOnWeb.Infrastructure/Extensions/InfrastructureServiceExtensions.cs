using eShopApplicationOnWeb.Application.Contracts.Infrastructure.Services;
using eShopApplicationOnWeb.Infrastructure.Identity.Extensions;
using eShopApplicationOnWeb.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace eShopApplicationOnWeb.Infrastructure.Extensions
{
    public static class InfrastructureServiceExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddIdentityServices(configuration);

            services.AddScoped<ICurrentUserService, CurrentUserService>();

            return services;
        }
    }
}
