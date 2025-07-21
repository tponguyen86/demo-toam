using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using web_client.Application.IServices;
using web_client.Models;
using web_client.Models.Data.Contexts;

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
            var products = await _dbContext.Products.ToListAsync(cancellationToken);
            var bannerModel = await _layoutService.GetHomeBannerSliderAsync(cancellationToken);
            ViewData["HomeBannerSliderDataModel"] = bannerModel;
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
        #region Product

        #endregion
        //public async Task<IActionResult> Product([FromServices] IProductAppService services, ProductPagingRequest request, CancellationToken cancellationToken)
        //{
        //    var resultProduct = await services.GetPagingAsync(request, cancellationToken);
        //    var responseData = resultProduct.Data;
        //    return View();
        //}  
        public async Task<IActionResult> Product(CancellationToken cancellationToken)
        {
            //var resultProduct = await services.GetPagingAsync(request, cancellationToken);
            //var responseData = resultProduct.Data;
            return View();
        }
        public IActionResult ProductDetail()
        {
            return View();
        }
        public IActionResult Service()
        {
            return View();
        }

        public IActionResult ServiceDetail()
        {
            return View();
        }
        public IActionResult Blog()
        {
            return View();
        }

        public IActionResult BlogDetail()
        {
            return View();
        }

        public IActionResult PageDetail()
        {
            return View();
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
