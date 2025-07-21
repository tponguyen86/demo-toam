using web_client.Models.Htmls.Carousels;

namespace web_client.Domain.IServices;

public interface ILayoutService
{
    Task<List<BaseCarouselItemModel>> GetHomeBannerSliderAsync(CancellationToken cancellationToken);
}