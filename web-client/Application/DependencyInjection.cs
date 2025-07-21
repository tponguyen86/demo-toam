using web_client.Application.IServices;
using web_client.Application.Services;

namespace web_client.Application;

public static class DependencyInjection
{
    public static void AddApplicationService(this IServiceCollection services)
    {
        services.AddScoped<IProductAppService, ProductAppService>();
        services.AddScoped<ITestimonialAppService, TestimonialAppService>();
        services.AddScoped<ILookupAppService, LookupAppService>();

        services.AddScoped<ILayoutAppService, LayoutAppService>();
    }
}
