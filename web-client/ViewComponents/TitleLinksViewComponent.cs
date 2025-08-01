using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using web_client.Helpers.Shared;
using web_client.Models.Htmls.Base;
using web_client.Models.Htmls.Common;
using web_client.Models.Htmls.TitleLinks;
namespace web_client.ViewComponents;

public class TitleLinksViewComponent : ViewComponent
{
    private readonly TitleLinksDefaultConfig _defaults;
    private readonly ILogger<TitleLinksViewComponent> _logger;

    public TitleLinksViewComponent(IOptions<TitleLinksDefaultConfig> defaults, ILogger<TitleLinksViewComponent> logger)
    {
        _defaults = defaults.Value;
        _logger = logger;
    }
    public async Task<IViewComponentResult> InvokeAsync(
       ViewComponentModel<TitleLinksSettingModel, List<TitleLinksComponent>> request)
    {
        var settingResponse = GetSettingModel(request);
        ViewData[ViewComponentConst.ViewBagKey.Key.TitleLinksSettingModel] = settingResponse;
        var responseData = request.GetData();
        if (!string.IsNullOrWhiteSpace(request.ViewName))
            return View(request.ViewName, responseData);

        return View(responseData);
    }
    protected TitleLinksSettingModel GetSettingModel<TData>(ViewComponentModel<TitleLinksSettingModel, TData> request) where TData : class
    {
        var setting = new TitleLinksSettingModel();
        setting.Merge(request.ViewSettingRequest);

        var componentName = GetType().Name.Replace("ViewComponent", "");

        return setting;
    }

}