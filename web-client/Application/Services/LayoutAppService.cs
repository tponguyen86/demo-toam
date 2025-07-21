using web_client.Application.IServices;
using web_client.Domain.IServices;
using web_client.Models.Htmls.Carousels;

namespace web_client.Application.Services;

public class LayoutAppService : ILayoutAppService
{
    private readonly ILayoutService _layoutService;

    public LayoutAppService(ILayoutService layoutService)
    {
        _layoutService = layoutService;
    }

    public Task<List<BaseCarouselItemModel>> GetHomeBannerSliderAsync(CancellationToken cancellationToken)
    => _layoutService.GetHomeBannerSliderAsync(cancellationToken);
}
