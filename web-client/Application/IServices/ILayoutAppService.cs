using web_client.Models.Htmls.Carousels;

namespace web_client.Application.IServices;
public interface ILayoutAppService
{
    Task<List<BaseCarouselItemModel>> GetHomeBannerSliderAsync(CancellationToken cancellationToken);
}