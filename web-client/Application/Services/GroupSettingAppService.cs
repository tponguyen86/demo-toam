using web_client.Application.IServices;
using web_client.Domain.IServices;
using web_client.Helpers;
using web_client.Models.Base;
using web_client.Models.Request.GroupProductSettings;
using web_client.Models.Response.Categories.Products;
using web_client.Models.Response.GroupProductSettings;

namespace web_client.Application.Services;

public class GroupSettingAppService : IGroupSettingAppService
{
    private readonly IGroupSettingService _groupSettingservice;
    private readonly ICategoryService _categoryService;

    public GroupSettingAppService(IGroupSettingService service, ICategoryService categoryService)
    {
        _groupSettingservice = service;
        _categoryService = categoryService;
    }

    public async Task<BaseProcess<GroupProductSettingDetailResponse>> GetGroupProductSettingDetailByCategoryId(Guid categoryId)
    {
        var settingResponse = await _categoryService.GetGroupProductSettingByProductCategoryId(categoryId, CancellationToken.None);
        if (settingResponse == null) return BaseProcess<GroupProductSettingDetailResponse>.Success(null);

        var settingResponseData = settingResponse?.Data as GetGroupProductSettingByProductCategoryIdResponse;
        if (settingResponseData?.OutputGroupSettingId.HasValueGuid() != true) return BaseProcess<GroupProductSettingDetailResponse>.Success(null);
        //2. get detail setting 
        var groupProductSettingRequest = new GroupProductSettingDetailRequest(settingResponseData.OutputGroupSettingId);
        var groupSettingResponse = await _groupSettingservice.GetGroupProductSettingDetail(groupProductSettingRequest, CancellationToken.None);
        return BaseProcess<GroupProductSettingDetailResponse>.Success(groupSettingResponse?.Data);
    }
}
