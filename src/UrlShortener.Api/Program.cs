var builder = WebApplication.CreateBuilder(args);

UrlShortener.Api.Startup.Services.Add(builder.Services, builder.Environment, builder.Configuration);

var app = builder.Build();

UrlShortener.Api.Startup.Middlewares.Use(app, builder.Environment, builder.Configuration);

app.Run();
