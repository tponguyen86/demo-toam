using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using web_client.Helpers;
using web_client.Models.Base;
using web_client.Models.Htmls;
namespace web_client.ViewComponents;

public class TestimonialViewComponent : ViewComponent
{
    private readonly CarouselDefaultsConfig _defaults;
    private readonly ILogger<TestimonialViewComponent> _logger;

    public TestimonialViewComponent(IOptions<CarouselDefaultsConfig> defaults, ILogger<TestimonialViewComponent> logger)
    {
        _defaults = defaults.Value;
        _logger = logger;
    }

    public async Task<IViewComponentResult> InvokeAsync(ViewComponentRequestModel<CarouselModel> carouselRequest)
    {
        var carouselResponse = new CarouselModel { Option = new CarouselOptionModel() };

        // 1. Infer component name (e.g., "Testimonial" from "TestimonialViewComponent")
        var componentName = GetType().Name.Replace("ViewComponent", "");

        // 2. Try to load scoped defaults
        if (_defaults.CarouselDefaults.TryGetValue(componentName, out var scopedDefaults))
        {
            carouselResponse.Option.Merge(scopedDefaults);
        }
        else
        {
            _logger.LogWarning("No scoped carousel defaults found for component: {Component}", componentName);
        }

        // 3. Apply per-instance overrides
        if (carouselRequest?.ViewRequest?.Option != null)
        {
            carouselResponse.Option.Merge(carouselRequest.ViewRequest.Option);
        }


        ViewData["CarouselModel"] = carouselResponse;

        if (carouselRequest?.ViewName.HasValueString() == true)
            return View(carouselRequest?.ViewName);
        
        return View();
    }
}