using Boilerplate.API.Constants;
using Boilerplate.API.Controllers;
using Boilerplate.Common.Config;
using Boilerplate.Common.Repository;
using Boilerplate.DataAccess.EFCustomizations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Boilerplate.API
{
    public static class Startup
    {
        public static void Register(this WebApplicationBuilder builder)
        {
            // Add services to the container.
            var services = builder.Services;
            var configuration = builder.Configuration;


            services.Configure<ApplicationConfig>(configuration);

            builder.Host.ConfigureAppConfiguration(options =>
            {
                options.AddJsonFile("appsettings.json", false);
                options.AddUserSecrets<ProductController>(true);
            });

            services.AddControllers();
            services.Add(ServiceDescriptor.Singleton(typeof(IOptionsSnapshot<>), typeof(OptionsManager<>)));
            services.AddDistributedMemoryCache();
            services.AddDbContext<IBoilerplateDbContext, BoilerplateDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString(ConnectionStringNames.BoilerplateDbContext));
            });

            services.AddSwaggerGen();
        }

        public static void Build(this WebApplication app)
        {
            var services = app.Services;
            var configuration = app.Configuration;

            using (var scope = services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<BoilerplateDbContext>();
                dbContext.Database.Migrate();

                if (app.Environment.IsDevelopment())
                {
                    //dbContext.Initializ();
                }
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors("DefaultAnyOriginPolicy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.Map("/", () => "Hello from Training API");
            });
            app.UseSwagger();
            app.UseSwaggerUI(o =>
            {
                o.SwaggerEndpoint("/swagger/v1/swagger.json", "BoilerplateAPI");
                //o.OAuthClientId(configuration["SwaggerClientAd:ClientId"]);
            });
        }
    }
}
