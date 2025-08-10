using eShopApplicationOnWeb.Infrastructure.Extensions;
<<<<<<< HEAD
using eShopApplicationOnWeb.WebAPI.Extensions;
=======
using eShopApplicationOnWeb.WebAPI.Extensions.Middleware;
>>>>>>> 9d33c8485c99f9bb57ad00151ff12002bfeef34a

namespace eShopApplicationOnWeb.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services
                .AddWebApiServices()
                .AddInfrastructureServices(builder.Configuration);
         

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            var app = builder.Build();

            app.UseGlobalExceptionHandler();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();

                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/openapi/v1.json", "OpenAPI V1");
                });
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
