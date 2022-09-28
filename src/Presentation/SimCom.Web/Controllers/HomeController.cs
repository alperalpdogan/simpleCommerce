using Microsoft.AspNetCore.Mvc;
using SimCom.Web.Factories;
using SimCom.Web.Models;
using System.Diagnostics;

namespace SimCom.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductModelFactory _productModelFactory;

        public HomeController(ILogger<HomeController> logger,
                              IProductModelFactory productModelFactory)
        {
            _logger = logger;
            _productModelFactory = productModelFactory;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productModelFactory.GetMainPageProductsAsync();
            return View(products);
        }

        public async Task<IActionResult> Product(string mainProductId)
        {
            //get combinations for the product with same productmainId
            // _productService.GetProductsByMainIdAsync(mainProductId)
            return Ok();
        }

        public IActionResult Privacy()
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