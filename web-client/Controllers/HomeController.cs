using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;
using web_client.IServices;
using web_client.Models;
using web_client.Models.Base;
using web_client.Models.Htmls.Carousels;

namespace web_client.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ILayoutService _layoutService;


        public HomeController(ILogger<HomeController> logger, ILayoutService layoutService)
        {
            _logger = logger;
            _layoutService = layoutService;
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
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
        public IActionResult Product()
        {
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
