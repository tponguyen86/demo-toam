﻿using web_client.Application.IServices;
using web_client.Domain.IServices;
using web_client.Models.Base;
using web_client.Models.Request.Categories.Products;
using web_client.Models.Responses.Categories.Products;
using static web_client.Helpers.Shared.PredefineDataConst;

namespace web_client.Application.Services;

public class ProductCategoryAppService : IProductCategoryAppService
{
    private readonly IProductCategoryService _service;

    public ProductCategoryAppService(IProductCategoryService service)
    {
        _service = service;
    }

    public async Task<BaseProcess<IEnumerable<ProductCategoryItemResponse>>> GetAllAsync(CancellationToken cancellationToken)
    {
        var request = new GetProductCategoryAllRequest();
        request.Discriminator = CategoryDiscriminator.Key.ProductCategory;
        var result = await _service.GetAllAsync(request, cancellationToken);
        return new BaseProcess<IEnumerable<ProductCategoryItemResponse>>(result.Data, result?.Errors);
    }

    public async Task<BaseProcess<IEnumerable<ProductCategoryItemResponse>>> GetByShowHomeAsync(CancellationToken cancellationToken)
    {
        var request = new GetProductCategoryAllRequest();
        request.Discriminator = CategoryDiscriminator.Key.ProductCategory;
        request.ShowHome = true;
        var result = await _service.GetAllAsync(request, cancellationToken);
        return new BaseProcess<IEnumerable<ProductCategoryItemResponse>>(result.Data, result?.Errors);
    }

    public async Task<BaseProcess<IEnumerable<ProductCategoryItemResponse>>> GetByShowMenuAsync(CancellationToken cancellationToken)
    {
        var request = new GetProductCategoryAllRequest();
        request.Discriminator = CategoryDiscriminator.Key.ProductCategory;
        request.ShowMenu = true;
        var result = await _service.GetAllAsync(request, cancellationToken);
        return new BaseProcess<IEnumerable<ProductCategoryItemResponse>>(result.Data, result?.Errors);
    }

    public Task<BaseProcess<ProductCategoryDetailResponse>> GetDetailAsync(BaseDetailRequestDto request, CancellationToken cancellationToken)
   => _service.GetDetailAsync(request, cancellationToken);
}
