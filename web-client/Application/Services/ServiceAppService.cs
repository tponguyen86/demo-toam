﻿using web_client.Application.IServices;
using web_client.Domain.IServices;
using web_client.Models.Base;
using web_client.Models.Request.Services;
using web_client.Models.Response.Services;

namespace web_client.Application.Services;

public class ServiceAppService : IServiceAppService
{
    private readonly IServiceService _service;

    public ServiceAppService(IServiceService service)
    {
        _service = service;
    }

    public Task<BaseProcess<ServiceDetailResponse>> GetDetailAsync(BaseDetailRequestDto request, CancellationToken cancellationToken)
    => _service.GetDetailAsync(request, cancellationToken);

    public async Task<BaseProcess<IEnumerable<ServiceItemResponse>>> GetFeatureAsync(int? take, CancellationToken cancellationToken = default)
    {
        var request = new ServicePagingRequest();
        request.PageSize = take ?? 5;
        request.Featured = true;
        var result = await _service.GetPagingAsync(request, cancellationToken);
        return new BaseProcess<IEnumerable<ServiceItemResponse>>(result?.Data?.Items, result?.Errors);
    }

    public Task<BaseProcess<BasePagingModel<ServiceItemResponse>>> GetPagingAsync(ServicePagingRequest request, CancellationToken cancellationToken)
    => _service.GetPagingAsync(request, cancellationToken);
}
