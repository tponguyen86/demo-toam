using web_client.Models.Base;
using web_client.Models.Htmls.Carousels;
using web_client.Models.Request.SystemConfigurations;
using web_client.Models.Response.SystemConfigurations;

namespace web_client.Domain.IServices;

public interface ILayoutService
{
    Task<List<BaseCarouselItemModel>> GetHomeBannerSliderAsync(CancellationToken cancellationToken);
    Task<BaseProcess<List<SystemConfigurationItemResponse>>> GetAllSystemConfigurationAsync(GetAllSystemConfigurationRequest request, CancellationToken cancellationToken);
    Task<BaseProcess<SystemConfigurationDetailResponse>> GetSystemConfigurationDetailAsync(BaseDetailRequestDto request, CancellationToken cancellationToken);
}