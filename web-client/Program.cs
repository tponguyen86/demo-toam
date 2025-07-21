using Microsoft.EntityFrameworkCore;
using Npgsql;
using System.Text.Json;
using web_client.Application;
using web_client.Domain;
using web_client.Models.Data.Contexts;
using web_client.Models.Htmls.Carousels;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
NpgsqlConnection.GlobalTypeMapper.EnableDynamicJson();
builder.Services.AddDbContext<NetectManageContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllersWithViews()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    });

builder.Services.Configure<CarouselDefaultConfig>(
builder.Configuration.GetSection("CarouselDefaults"));
builder.Services.AddDomainService();
builder.Services.AddApplicationService();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
