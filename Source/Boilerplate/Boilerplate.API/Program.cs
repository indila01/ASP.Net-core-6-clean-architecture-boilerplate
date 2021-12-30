using Boilerplate.Common.Repository
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var services = builder.Services;
var configuration = builder.Configuration;


services.Configure<ApplicationConfig>(configuration);
services.AddControllers();
services.Add(ServiceDescriptor.Singleton(typeof(IOptionsSnapshot<>), typeof(OptionsManager<>)));
services.AddDistributedMemoryCache();
services.AddDbContext<IDbContext>


var app = builder.Build();

builder.Host.ConfigureAppConfiguration(options =>
{
    options.AddJsonFile("appsettings.json", false);
    //options.AddUserSecrets<AuthController>(true);
});

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
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

