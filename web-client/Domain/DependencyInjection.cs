using web_client.Domain.IServices;
using web_client.Domain.Services;

namespace web_client.Domain;

public static class DependencyInjection
{
    public static void AddDomainService(this IServiceCollection services)
    {
        services.AddScoped<ITestimonialService, TestimonialService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<ILookupService, LookupService>();

        services.AddScoped<ILayoutService, LayoutService>();
    }
}
