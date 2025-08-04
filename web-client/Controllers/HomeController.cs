using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using web_client.Application.IServices;
using web_client.Helpers;
using web_client.Helpers.Shared;
using web_client.Models;
using web_client.Models.Base;
using web_client.Models.Data.Contexts;
using web_client.Models.Htmls.Common;
using web_client.Models.Request.News;
using web_client.Models.Request.Products;
using web_client.Models.Request.Services;

namespace web_client.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ILayoutAppService _layoutService;
        private readonly NetectManageContext _dbContext;

        public HomeController(ILogger<HomeController> logger, NetectManageContext dbContext, ILayoutAppService layoutService)
        {
            _logger = logger;
            _dbContext = dbContext;
            _layoutService = layoutService;
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            //var products = await _dbContext.Products.ToListAsync(cancellationToken);
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult ProductCategory()
        {
            return View();
        }
        public IActionResult ProductCategoryDetail()
        {
            return View();
        }

        [Route("san-pham/{seoKeyCategory?}")]
        public async Task<IActionResult> Product([FromServices] IProductAppService services, [FromServices] IProductCategoryAppService categoryServices, ProductPagingRequest request, string? seoKeyCategory, CancellationToken cancellationToken)
        {
            var getCategoryDetail = await categoryServices.GetDetailAsync(new BaseDetailRequestDto(seoKeyCategory));
            var categoryIds = getCategoryDetail?.Data?.ChildModel?.GetAllId();
            if (categoryIds?.Any() == true)
                request.SetCategory(categoryIds);

            var resultProduct = await services.GetPagingAsync(request, cancellationToken);
            if (resultProduct.HasError)
                return RedirectToAction("Service");
            var responseData = resultProduct.Data;
            var model = responseData?.Items?.Select(x => new ProductTitleMediaComponent(x));
            var response = responseData.GetPaging(model);
            ViewBag.paging = response?.BuildPaging($"{RouteConst.GetRoute(RouteConst.Product)}?page={0}");
            return View(response);
        }

        [Route("san-pham/{seoKey}/chi-tiet")]
        public async Task<IActionResult> ProductDetail([FromServices] IProductAppService services, string seoKey, CancellationToken cancellationToken)
        {
            var resultProduct = await services.GetDetailAsync(new BaseDetailRequestDto(seoKey), cancellationToken);
            var responseData = resultProduct.Data;
            var response = new ProductTitleMediaDetailComponent(responseData);
            return View(response);
        }
        [Route("dich-vu/{seoKeyCategory?}")]
        public async Task<IActionResult> Service([FromServices] IServiceAppService services, [FromServices] IServiceCategoryAppService categoryServices, string? seoKeyCategory,ServicePagingRequest request, CancellationToken cancellationToken)
        {
            var getCategoryDetail = await categoryServices.GetDetailAsync(new BaseDetailRequestDto(seoKeyCategory));
            var categoryIds = getCategoryDetail?.Data?.ChildModel?.GetAllId();
            if (categoryIds?.Any() == true)
                request.SetCategory(categoryIds);
            else
                request.AddCategory(PredefineDataConst.CategoryParentId.Key.Service.GetGuid());

            var result = await services.GetPagingAsync(request, cancellationToken);
            var responseData = result.Data;
            var model = responseData?.Items?.Select(x => new ArticleTitleMediaComponent()
            {
                CreatedAt = x.CreatedAt,
                CreatedBy = new BaseMediaLinkModel($"{x.CreatedByModel?.Label}", $"{x.CreatedByModel?.Key}"),
                ShortDescription = x.ShortDescription,
                Group = new BaseMediaLinkModel($"{x.ParentIdModel?.Label}", $"{x.ParentIdModel?.Key}"),
                Href = string.Format(RouteConst.GetRoute(RouteConst.ServiceDetail), x.PageKeyName),
                Media = x?.Image?.Path,
                Id = x.Id,
                Title = x.Name,
            });
            var response = responseData.GetPaging(model);
            ViewBag.paging = response?.BuildPaging($"{RouteConst.GetRoute(RouteConst.Service)}?page={0}");
            return View(response);
        }

        [Route("dich-vu/{seoKey}/chi-tiet")]
        public async Task<IActionResult> ServiceDetail([FromServices] IServiceAppService services, string seoKey, CancellationToken cancellationToken)
        {
            var result = await services.GetDetailAsync(new BaseDetailRequestDto(seoKey), cancellationToken);
            if (result.HasError)
                return RedirectToAction("Service");

            var responseData = result.Data;
            var response = new ArticleTitleMediaDetailComponent()
            {
                CreatedAt = responseData.CreatedAt,
                CreatedBy = new BaseMediaLinkModel($"{responseData.CreatedByModel?.Label}", $"{responseData.CreatedByModel?.Key}"),
                ShortDescription = responseData.ShortDescription,
                Group = new BaseMediaLinkModel($"{responseData.ParentIdModel?.Label}", $"{responseData.ParentIdModel?.Key}"),
                Href = string.Format(RouteConst.GetRoute(RouteConst.ServiceDetail), responseData.PageKeyName),
                Media = responseData?.Image?.Path,
                Id = responseData.Id,
                Title = responseData.Name,
                Content = responseData.Content
            };
            return View(response);
        }

        [Route("tin-tuc/{seoKeyCategory?}")]
        public async Task<IActionResult> Blog([FromServices] INewsAppService services, [FromServices] INewsCategoryAppService categoryServices, NewsPagingRequest request, string? seoKeyCategory, CancellationToken cancellationToken)
        {
            var getCategoryDetail = await categoryServices.GetDetailAsync(new BaseDetailRequestDto(seoKeyCategory));
            var categoryIds = getCategoryDetail?.Data?.ChildModel?.GetAllId();
            if (categoryIds?.Any() == true)
                request.SetCategory(categoryIds);
            else
                request.AddCategory(PredefineDataConst.CategoryParentId.Key.News.GetGuid());

            var result = await services.GetPagingAsync(request, cancellationToken);
            var responseData = result.Data;
            var model = responseData?.Items?.Select(x => new ArticleTitleMediaComponent()
            {
                CreatedAt = x.CreatedAt,
                CreatedBy = new BaseMediaLinkModel($"{x.CreatedByModel?.Label}", $"{x.CreatedByModel?.Key}"),
                ShortDescription = x.ShortDescription,
                Group = new BaseMediaLinkModel($"{x.ParentIdModel?.Label}", $"{x.ParentIdModel?.Key}"),
                Href = string.Format(RouteConst.GetRoute(RouteConst.NewsDetail), x.PageKeyName),
                Media = x?.Image?.Path,
                Id = x.Id,
                Title = x.Name,
            });
            var response = responseData.GetPaging(model);
            ViewBag.paging = response?.BuildPaging($"{RouteConst.GetRoute(RouteConst.News)}?page={0}");
            return View(response);
        }

        [Route("tin-tuc/{seoKey}/chi-tiet")]
        public async Task<IActionResult> BlogDetail([FromServices] INewsAppService services, string seoKey, CancellationToken cancellationToken)
        {
            var result = await services.GetDetailAsync(new BaseDetailRequestDto(seoKey), cancellationToken);
            if (result.HasError)
                return RedirectToAction("Blog");

            var responseData = result.Data;
            var response = new ArticleTitleMediaDetailComponent()
            {
                CreatedAt = responseData.CreatedAt,
                CreatedBy = new BaseMediaLinkModel($"{responseData.CreatedByModel?.Label}", $"{responseData.CreatedByModel?.Key}"),
                ShortDescription = responseData.ShortDescription,
                Group = new BaseMediaLinkModel($"{responseData.ParentIdModel?.Label}", $"{responseData.ParentIdModel?.Key}"),
                Href = string.Format(RouteConst.GetRoute(RouteConst.NewsDetail), responseData.PageKeyName),
                Media = responseData?.Image?.Path,
                Id = responseData.Id,
                Title = responseData.Name,
                Content = responseData.Content
            };

            return View(response);
        }

        [Route("trang/{seoKey}")]
        public async Task<IActionResult> PageDetail([FromServices] IPageAppService services, string seoKey, CancellationToken cancellationToken)
        {
            var result = await services.GetDetailAsync(new BaseDetailRequestDto(seoKey), cancellationToken);
            if (result.HasError)
                return RedirectToAction("Index");

            var responseData = result.Data;
            var response = new PageTitleMediaDetailComponent()
            {
                Href = string.Format(RouteConst.GetRoute(RouteConst.PageDetail), responseData.PageKeyName),
                Media = responseData?.Image?.Path,
                Id = responseData.Id,
                Title = responseData.Name,
                Content = responseData.Description
            };
            return View(response);
        }

        public IActionResult Contact()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
