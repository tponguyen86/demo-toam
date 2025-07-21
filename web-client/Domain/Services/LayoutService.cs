using web_client.Domain.IServices;
using web_client.Models.Base;
using web_client.Models.Htmls.Carousels;

namespace web_client.Domain.Services;

public class LayoutService : ILayoutService
{
    public async Task<List<BaseCarouselItemModel>> GetHomeBannerSliderAsync(CancellationToken cancellationToken)
    {
        var bannerModel = new List<BaseCarouselItemModel>()
            {
                new BaseCarouselItemModel()
                {
                    Title= "Top 10",
                    Image=new BaseFileModel(){Path="https://img.hoplongtech.com/hoplong/logo-hang/banner-1/top-10-noi-lam-viec.jpg",Alt="Top 10"}
                }, new BaseCarouselItemModel()
                {
                    Title= "Top 500",
                    Image=new BaseFileModel(){Path="https://img.hoplongtech.com/hoplong/logo-hang/banner-1/hanyoung-nux-1.jpg",Alt="Top 500"}
                }
            };
        await Task.CompletedTask;
        return bannerModel;
    }
}