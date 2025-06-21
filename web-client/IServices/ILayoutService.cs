using web_client.Models.Htmls.Carousels;

namespace web_client.IServices;

public interface ILayoutService
{
    Task<List<BaseCarouselItemModel>> GetHomeBannerSliderAsync(CancellationToken cancellationToken);
}