namespace eShopApplicationOnWeb.WebAPI.Extensions
{
    public static class WebApiServiceExtensions
    {
        public static IServiceCollection AddWebApiServices(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();

            return services;
        }
    }
}
