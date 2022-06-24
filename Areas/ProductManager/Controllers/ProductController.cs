using AppMVC.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace AppMVC.Controllers
{
    [Area("ProductManager")]
    public class ProductController : Controller
    {
        private readonly ProductService _productService;
        private readonly ILogger<ProductController> _logger;
        public ProductController(ProductService productSerice, ILogger<ProductController> logger)
        {
            _productService = productSerice;
            _logger = logger;

        }
        public IActionResult Index()
        {
            var products = _productService.OrderBy(p=>p.Name).ToList();
            return View(products);
        }
    }
}
