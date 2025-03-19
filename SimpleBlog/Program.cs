using Microsoft.EntityFrameworkCore;
using SimpleBlog.Api.Extensions.Services;
using SimpleBlog.Api.Extensions.WebApp;
using SimpleBlog.Api.Mapping;
using SimpleBlog.Infra.CrossCutting.IoC;
using SimpleBlog.Infra.Data.Context;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerServiceExtension();

builder.Services.AddAuthServiceExtension(builder.Configuration);

builder.Services.AddAutoMapper(x => x.AddProfile<MappingProfile>());

builder.Services.AddDbContext<AppDatabaseContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("SimpleBlog.Api"));
});

var myhandlers = AppDomain.CurrentDomain.Load("SimpleBlog.Application");
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblies(myhandlers);
});

DependencyInjection.RegisterServices(builder.Services);

var app = builder.Build();

app.UseSwaggerAppExtension();

app.UseCors();
app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();

app.MapControllers();

var webSocketOptions = new WebSocketOptions
{
    KeepAliveInterval = TimeSpan.FromMinutes(2)
};

app.UseWebSockets(webSocketOptions);

app.UseDefaultFiles();
app.UseStaticFiles();

app.Run();
