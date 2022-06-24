using AppMVC.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Linq;

namespace AppMVC.Controllers
{
    public class FirstController : Controller
    {
        private readonly ProductService _productService;

        private readonly ILogger _logger;
        public FirstController(ILogger<FirstController> logger, ProductService productService)
        {
            _productService = productService;
            _logger = logger;
        }
        public string Index()
        {
            //logger.LogInformation("Index Action");
            return "Tôi là Index của FirstCOntroller";
        }

        public void Nothing()
        {
            _logger.LogInformation("Nothing Action ff");
            // Response.Headers.Add("hi", "Xin chào các bạn");
        }
        public object Anything()
        {
            return new int[] { 1, 2, 3 } + "sdfdsf";
        }

        public IActionResult ReadMe()
        {
            var content = @"
                            dsfdsfdsfdsfds
                                        fdsfdsfdsfds
                                dấdsa
                        ";
            return Content(content);
        }

        public IActionResult Bird()
        {
            string filePath = Path.Combine(Startup.ContetnRootPath, "Files", "download.jpg");
            //Save to Byte Array
            var bytes = System.IO.File.ReadAllBytes(filePath);

            return File(bytes, "image/jpg");
        }

        public IActionResult IphonePrice()
        {
            //return Json format
            return Json(new
            {
                productName = "Iphone",
                Price = 1000
            });
        }

        public IActionResult Privacy()
        {
            var url = Url.Action("Privacy", "Home");
            _logger.LogInformation("Chuyển hướng đến " + url);

            return LocalRedirect(url);
        }
        public IActionResult Google()
        {
            var url = "https://google.com";
            _logger.LogInformation("Chuyển hướng đến " + url);

            return Redirect(url);
        }

        public IActionResult HelloView(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                username = "Khách";
            }
            //return View((object)username);

            return View("xinchao3", username);
        }

        [TempData]
        public string StatusMessage { get; set; }

        public IActionResult ViewProduct(int? id)
        { 
            var product =_productService.Where(p=>p.Id == id).FirstOrDefault();
            if (product ==null)
            {
                //TempData["StatusMessage"] = "Your product not found";
                StatusMessage = "Your product not found";
                return Redirect(Url.Action("Index", "Home"));
            }
            //return View(product);
            //this.ViewData["product"] = product;
            //this.ViewData["Title"] = product.Name;

            // Transfer Data between Pages
           
            this.ViewBag.product = product;
            return View("ViewProduct3");
        }
    }
}
