using Boilerplate.API.Constants;
using Boilerplate.Common.Config;
using Boilerplate.Common.Repository;
using Boilerplate.DataAccess.EFCustomizations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var services = builder.Services;
var configuration = builder.Configuration;


services.Configure<ApplicationConfig>(configuration);

builder.Host.ConfigureAppConfiguration(options =>
{
    options.AddJsonFile("appsettings.json", false);
    //options.AddUserSecrets<AuthController>(true);
});

services.AddControllers();
services.Add(ServiceDescriptor.Singleton(typeof(IOptionsSnapshot<>), typeof(OptionsManager<>)));
services.AddDistributedMemoryCache();
services.AddDbContext<IBoilerplateDbContext, BoilerplateDbContext>(options =>
{
    options.UseSqlServer(configuration.GetConnectionString(ConnectionStringNames.SpaceRunnerTrainingDbContext));
});

// Configure the HTTP request pipeline.
var app = builder.Build();

var buildServices = app.Services;
using (var scope = buildServices.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<BoilerplateDbContext>();
    dbContext.Database.Migrate();

    if (app.Environment.IsDevelopment())
    {
        //dbContext.Initialize()
    }
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.Map("/", () => "Boilerplate API running");
});


app.Run();

