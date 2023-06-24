using Boilerplate.API;

var builder = WebApplication.CreateBuilder(args);

builder.Register();

var app = builder.Build();

app.Build();
app.Run();