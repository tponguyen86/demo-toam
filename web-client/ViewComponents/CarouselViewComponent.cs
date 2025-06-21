using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using web_client.Helpers;
using web_client.Models.Htmls.Base;
using web_client.Models.Htmls.Carousels;
namespace web_client.ViewComponents;

public class CarouselViewComponent : ViewComponent
{
    private readonly CarouselDefaultConfig _defaults;
    private readonly ILogger<CarouselViewComponent> _logger;

    public CarouselViewComponent(IOptions<CarouselDefaultConfig> defaults, ILogger<CarouselViewComponent> logger)
    {
        _defaults = defaults.Value;
        _logger = logger;
    }
    public async Task<IViewComponentResult> InvokeAsync(
       ViewComponentModel<CarouselSettingModel, List<BaseCarouselItemModel>> carouselRequest)
    {
        var carouselSettingResponse = GetCarouselModel(carouselRequest);
        ViewData["CarouselSettingModel"] = carouselSettingResponse;
        //ViewData["CarouselDataModel"] = carouselRequest.GetData();
        var responseData= carouselRequest.GetData();
        if (!string.IsNullOrWhiteSpace(carouselRequest.ViewName))
            return View(carouselRequest.ViewName, responseData);

        return View(responseData);
    }
    //public async Task<IViewComponentResult> InvokeAsync(ViewComponentRequestModel<CarouselSettingModel, TData> carouselRequest)
    //{
    //    CarouselSettingModel carouselResponse = GetCarouselModel(carouselRequest);
    //    ViewData["CarouselSettingModel"] = carouselResponse;
    //    ViewData["CarouselDataModel"] = carouselRequest.GetData();
    //    if (carouselRequest?.ViewName.HasValueString() == true)
    //        return View(carouselRequest?.ViewName, carouselRequest.GetData());

    //    return View(carouselRequest.GetData());
    //}

    //public CarouselSettingModel GetCarouselModel(ViewComponentRequestModel<CarouselSettingModel, object> carouselRequest)
    //{
    //    var carouselSetting = new CarouselSettingModel { Option = new CarouselSettingOptionModel() };
    //    carouselSetting.Merge(carouselRequest.ViewSettingRequest);

    //    // 1. Infer component name (e.g., "Carousel" from "CarouselViewComponent")
    //    var componentName = GetType().Name.Replace("ViewComponent", "");

    //    // 2. Try to load scoped defaults
    //    if (_defaults.Setting.TryGetValue(componentName, out var scopedDefaults))
    //    {
    //        carouselSetting.Option.Merge(scopedDefaults);
    //    }
    //    else
    //    {
    //        _logger.LogWarning("No scoped carousel defaults found for component: {Component}", componentName);
    //    }

    //    // 3. Apply per-instance overrides
    //    if (carouselRequest?.ViewSettingRequest?.Option != null)
    //    {
    //        carouselSetting.Option.Merge(carouselRequest.ViewSettingRequest.Option);
    //    }

    //    return carouselSetting;
    //}

    protected CarouselSettingModel GetCarouselModel<TData>(ViewComponentModel<CarouselSettingModel, TData> carouselRequest) where TData : class
    {
        var carouselSetting = new CarouselSettingModel { Option = new CarouselSettingOptionModel() };
        carouselSetting.Merge(carouselRequest.ViewSettingRequest);

        // 1. Infer component name (e.g., "Carousel" from "CarouselViewComponent")
        var componentName = GetType().Name.Replace("ViewComponent", "");

        // 2. Try to load scoped defaults
        if (_defaults.Setting.TryGetValue(componentName, out var scopedDefaults))
        {
            carouselSetting.Option.Merge(scopedDefaults);
        }
        else
        {
            _logger.LogWarning("No scoped carousel defaults found for component: {Component}", componentName);
        }

        // 3. Apply per-instance overrides
        if (carouselRequest?.ViewSettingRequest?.Option != null)
        {
            carouselSetting.Option.Merge(carouselRequest.ViewSettingRequest.Option);
        }

        return carouselSetting;
    }

}