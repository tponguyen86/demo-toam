using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using web_client.Application.IServices;
using web_client.Helpers;
using web_client.Helpers.Shared;
using web_client.Models;
using web_client.Models.Base;
using web_client.Models.Data.Contexts;
using web_client.Models.Htmls;
using web_client.Models.Htmls.Base;
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

        public IActionResult Index(CancellationToken cancellationToken)
        {
            //var products = await _dbContext.Products.ToListAsync(cancellationToken);
            return View();
        }

        [Route("danh-muc")]
        public async Task<IActionResult> ProductCategory([FromServices] IProductCategoryAppService services, CancellationToken cancellationToken)
        {
            var result = await services.GetAllTopLevelAsync();
            if (result.HasError)
                return RedirectToAction("Index");

            var response = result.Data?.Select(x => new BaseCategoryItemModel(x)).ToList();
            return View(response);
        }

        [Route("danh-muc/{seoKey}/chi-tiet")]
        public async Task<IActionResult> ProductCategoryDetailAsync([FromServices] IProductCategoryAppService categoryServices, string? seoKey, CancellationToken cancellationToken)
        {
            var result = await categoryServices.GetDetailAsync(new BaseDetailRequestDto(seoKey));
            if (result.HasError)
                return RedirectToAction("ProductCategory");
            var responseData = result.Data;
            var response = new CategoryTitleLinksDetailComponent(responseData?.Name, responseData?.ChildModel?.Child?.Select(c => new BaseCategoryItemModel(c))?.ToList(), responseData?.ShortDescription);

            //var categoryIds = responseData?.ChildModel?.GetAllId();
            //if (categoryIds?.Any() == true)
            //    request.SetCategory(categoryIds);

            return View(response);
        }
        public bool IsAjaxRequest()
        {
            return Request.Headers["x-requested-with"] == "XMLHttpRequest";
        }

        [Route("san-pham/{seoKeyCategory?}")]
        public async Task<IActionResult> Product(
            [FromServices] IProductAppService services,
            [FromServices] IProductCategoryAppService categoryServices,
            ProductPagingRequest request,
            string? seoKeyCategory,
            CancellationToken cancellationToken)
        {
            request.SetCategoryKey(seoKeyCategory);

            request.Attributes = Request.Query.Where(x => x.Key.StartsWith("p-"));
            var pageModel = new PageModel() { Title = "Sản phẩm", Description = "Danh sách sản phẩm", BodyClassName = "p-product", MainClassName = "shop", Keywords = "danh sách sản phẩm, sản phẩm, sản phẩm mới, sản phẩm nổi bật" };

            var categoryDetailRequest = new BaseDetailRequestDto(seoKeyCategory);
            //if (seoKeyCategory?.HasValueString() != true) categoryDetailRequest.Id = PredefineDataConst.CategoryParentId.Key.Product.GetGuid();
            var getCategoryDetail = await categoryServices.GetDetailAsync(categoryDetailRequest);
            if (getCategoryDetail?.Data != null)
            {
                ViewData["ProductCategoryId"] = getCategoryDetail.Data.Id;

                pageModel.Title = getCategoryDetail.Data.Name;
                pageModel.Description = getCategoryDetail.Data.ShortDescription;
                pageModel.Keywords = getCategoryDetail.Data.MetaKeyword;
                pageModel.PageKeyName = getCategoryDetail.Data.PageKeyName;

                var categoryIds = getCategoryDetail?.Data?.ChildModel?.GetAllId();
                if (categoryIds?.Any() == true)
                    request.SetCategory(categoryIds);
            }

            var resultProduct = await services.GetPagingAsync(request, cancellationToken);
            if (resultProduct.HasError)
                return RedirectToAction("ProductCategory");
            var responseData = resultProduct.Data;
            var model = responseData?.Items?.Select(x => new ProductTitleMediaComponent(x));
            var response = responseData.GetPaging(model);
            ViewBag.paging = response?.BuildPaging($"{RouteConst.GetRoute(RouteConst.Product)}?page={0}");
            ViewBag.pagingRequest = request;

            //configure page model , seo meodel...
            ViewData["Page"] = pageModel;

            bool isAjaxCall = IsAjaxRequest();
            if (isAjaxCall)
            {
                // If it's an AJAX request, return a partial view or JSON response
                return PartialView("Components/_ProductListPartial", response);
            }
            return View(response);
        }

        [Route("san-pham/{seoKey}/chi-tiet")]
        public async Task<IActionResult> ProductDetail([FromServices] IProductAppService services, string seoKey, CancellationToken cancellationToken)
        {
            var resultProduct = await services.GetDetailAsync(new BaseDetailRequestDto(seoKey), cancellationToken);
            var response = new ProductTitleMediaDetailComponent(resultProduct.Data);
            return View(response);
        }

        [Route("dich-vu/{seoKeyCategory?}")]
        public async Task<IActionResult> Service([FromServices] IServiceAppService services, [FromServices] IServiceCategoryAppService categoryServices, string? seoKeyCategory, ServicePagingRequest request, CancellationToken cancellationToken)
        {
            var categoryDetailRequest = new BaseDetailRequestDto(seoKeyCategory);
            if (seoKeyCategory?.HasValueString() != true) categoryDetailRequest.Id = PredefineDataConst.CategoryParentId.Key.Service.GetGuid();
            var getCategoryDetail = await categoryServices.GetDetailAsync(categoryDetailRequest);
            var categoryIds = getCategoryDetail?.Data?.ChildModel?.GetAllId();
            if (categoryIds?.Any() == true)
                request.SetCategory(categoryIds);

            var result = await services.GetPagingAsync(request, cancellationToken);
            var responseData = result.Data;
            var model = responseData?.Items?.Select(x => new ArticleTitleMediaComponent()
            {
                CreatedAt = x.CreatedAt,
                CreatedBy = new BaseMediaLinkModel($"{x.CreatedByModel?.Label}", $"{x.CreatedByModel?.Key}"),
                ShortDescription = x.ShortDescription,
                Group = new BaseMediaLinkModel($"{x.ParentIdModel?.Label}", string.Format(RouteConst.GetRoute(RouteConst.ServiceCategory), x.ParentIdModel?.Key)),
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
                Group = new BaseMediaLinkModel($"{responseData.ParentIdModel?.Label}", string.Format(RouteConst.GetRoute(RouteConst.ServiceCategory), responseData.ParentIdModel?.Key)),
                Href = string.Format(RouteConst.GetRoute(RouteConst.ServiceDetail), responseData.PageKeyName),
                Media = responseData?.Image?.Path,
                Id = responseData.Id,
                Title = responseData.Name,
                Content = responseData.Content
            };
            return View(response);
        }

        [Route("tin-tuc/{seoKeyCategory?}")]
        public async Task<IActionResult> Blog(
            [FromServices] INewsAppService services,
            [FromServices] INewsCategoryAppService categoryServices,
            NewsPagingRequest request,
            string? seoKeyCategory,
            CancellationToken cancellationToken)
        {
            var pageModel = new PageModel() { Title = "Tin tức", Description = "Mô ta seo tin tức", BodyClassName = "p-blog", MainClassName = "shop" };

            var categoryDetailRequest = new BaseDetailRequestDto(seoKeyCategory);
            if (seoKeyCategory?.HasValueString() != true) categoryDetailRequest.Id = PredefineDataConst.CategoryParentId.Key.News.GetGuid();
            var getCategoryDetail = await categoryServices.GetDetailAsync(categoryDetailRequest);
            if (getCategoryDetail?.Data != null)
            {
                pageModel.Title = getCategoryDetail.Data.Name;
                pageModel.Description = getCategoryDetail.Data.ShortDescription;
                pageModel.Keywords = getCategoryDetail.Data.MetaKeyword;
                pageModel.PageKeyName = getCategoryDetail.Data.PageKeyName;

                var categoryIds = getCategoryDetail?.Data?.ChildModel?.GetAllId();
                if (categoryIds?.Any() == true)
                    request.SetCategory(categoryIds);
            }

            var result = await services.GetPagingAsync(request, cancellationToken);
            var responseData = result.Data;
            var model = responseData?.Items?.Select(x => new ArticleTitleMediaComponent()
            {
                CreatedAt = x.CreatedAt,
                CreatedBy = new BaseMediaLinkModel($"{x.CreatedByModel?.Label}", $"{x.CreatedByModel?.Key}"),
                ShortDescription = x.ShortDescription,
                Group = new BaseMediaLinkModel($"{x.ParentIdModel?.Label}", string.Format(RouteConst.GetRoute(RouteConst.NewsCategory), x.ParentIdModel?.Key)),
                Href = string.Format(RouteConst.GetRoute(RouteConst.NewsDetail), x.PageKeyName),
                Media = x?.Image?.Path,
                Id = x.Id,
                Title = x.Name,
            });
            var response = responseData.GetPaging(model);
            ViewBag.paging = response?.BuildPaging($"{RouteConst.GetRoute(RouteConst.News)}?page={0}");

            ViewData["Page"] = pageModel;
            return View(response);
        }

        [Route("tin-tuc/{seoKey}/chi-tiet")]
        public async Task<IActionResult> BlogDetail([FromServices] INewsAppService services, string seoKey, CancellationToken cancellationToken)
        {
            var pageModel = new PageModel() { Title = "Tin tức", Description = "Mô ta seo tin tức", BodyClassName = "p-blog-detail", MainClassName = "shop" };
            var result = await services.GetDetailAsync(new BaseDetailRequestDto(seoKey), cancellationToken);
            if (result.HasError)
                return RedirectToAction("Blog");

            var responseData = result.Data;
            var response = new ArticleTitleMediaDetailComponent()
            {
                CreatedAt = responseData.CreatedAt,
                CreatedBy = new BaseMediaLinkModel($"{responseData.CreatedByModel?.Label}", $"{responseData.CreatedByModel?.Key}"),
                ShortDescription = responseData.ShortDescription,
                Group = new BaseMediaLinkModel($"{responseData.ParentIdModel?.Label}", string.Format(RouteConst.GetRoute(RouteConst.NewsCategory), responseData.ParentIdModel?.Key)),
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

        [Route("lien-he")]
        public IActionResult Contact()
        {
            return View();
        }
        [Route("loi-xay-ra")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
