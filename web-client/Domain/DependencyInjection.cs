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
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IProductCategoryService, ProductCategoryService>();
        services.AddScoped<INewsCategoryService, NewsCategoryService>();
        services.AddScoped<IServiceCategoryService, ServiceCategoryService>();
        services.AddScoped<INewsService, NewsService>();
        services.AddScoped<IServiceService, ServiceService>();
        services.AddScoped<ISystemConfigurationService, SystemConfigurationService>();
        services.AddScoped<ILayoutService, LayoutService>();
        services.AddScoped<IPageService, PageService>();
        services.AddScoped<IPageConfigurationService, PageConfigurationService>();
    }
}
