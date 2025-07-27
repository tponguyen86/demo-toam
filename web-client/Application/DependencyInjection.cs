using web_client.Application.IServices;
using web_client.Application.Services;
using web_client.Domain.IServices;

namespace web_client.Application;

public static class DependencyInjection
{
    public static void AddApplicationService(this IServiceCollection services)
    {
        services.AddScoped<IProductAppService, ProductAppService>();
        services.AddScoped<ITestimonialAppService, TestimonialAppService>();
        services.AddScoped<IProductCategoryAppService, ProductCategoryAppService>();
        services.AddScoped<INewsCategoryAppService, NewsCategoryAppService>();
        services.AddScoped<IServiceCategoryAppService, ServiceCategoryAppService>();
        services.AddScoped<ILookupAppService, LookupAppService>();

        services.AddScoped<ILayoutAppService, LayoutAppService>();
    }
}
