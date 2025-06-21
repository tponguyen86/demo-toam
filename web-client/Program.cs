using System.Text.Json;
using web_client.IServices;
using web_client.Models.Htmls.Carousels;
using web_client.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
    });

builder.Services.Configure<CarouselDefaultConfig>(
    builder.Configuration.GetSection("CarouselDefaults"));

builder.Services.AddScoped<ITestimonialService, TestimonialService>();
builder.Services.AddScoped<ILayoutService, LayoutService>();

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
