using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using web_client.Helpers;
using web_client.IServices;
using web_client.Models.Htmls.Carousels;
using web_client.Models.Response;
namespace web_client.ViewComponents;

public class TestimonialViewComponent : CarouselViewComponent
{
    private readonly CarouselDefaultConfig _defaults;
    private readonly ILogger<TestimonialViewComponent> _logger;
    //can set in contructor or load from database
    private readonly ITestimonialService _testimonialService;
    public TestimonialViewComponent(IOptions<CarouselDefaultConfig> defaults, ILogger<TestimonialViewComponent> logger, ITestimonialService testimonialService) : base(defaults, logger)
    {
        _defaults = defaults.Value;
        _logger = logger;
        _testimonialService = testimonialService;
    }

    //public async Task<IViewComponentResult> InvokeAsync(ViewComponentRequestModel<CarouselSettingModel, List<TestimonialItemModel>> carouselRequest, CancellationToken cancellationToken)
    //{
    //    CarouselSettingModel carouselSetting = GetCarouselModel(carouselRequest);
    //    ViewData["CarouselSettingModel"] = carouselSetting;
    //    var testimonials = await _testimonialService.GetTestimonialsAsync(cancellationToken);
    //    ViewData["CarouselDataModel"] = testimonials;
    //    if (carouselRequest?.ViewName.HasValueString() == true)
    //        return View(carouselRequest?.ViewName, testimonials);

    //    return View(testimonials);
    //}


}